using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly GuildRepository guilds;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.guilds = new GuildRepository();
        }
        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != "Warrior" && heroTypeName != "Sorcerer" && heroTypeName != "Spellblade")
            {
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            if (heroes.GetModel(runeMark) != null)
            {
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            }

            IHero hero;

            if (heroTypeName == "Warrior")
            {
                hero = new Warrior(heroName, runeMark);
            }
            else if (heroTypeName == "Sorcerer")
            {
                hero = new Sorcerer(heroName, runeMark);
            }
            else
            {
                hero = new Spellblade(heroName, runeMark);
            }

            heroes.AddModel(hero);
            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
            {
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            guilds.AddModel(new Guild(guildName));

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            if (heroes.GetModel(runeMark) == null)
            {
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            }

            if (guilds.GetModel(guildName) == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            IHero hero = heroes.GetModel(runeMark);

            if (hero.GuildName != null)
            {
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
            }

            IGuild guild = guilds.GetModel(guildName);

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildIsFallen, guild.Name);
            }

            if (guild.Wealth < 500)
            {
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Name);
            }

            if (hero is Warrior && guild.Name != "WarriorGuild" && guild.Name != "ShadowGuild")
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guild.Name);
            }
            else if (hero is Sorcerer && guild.Name != "SorcererGuild" && guild.Name != "ShadowGuild")
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guild.Name);
            }
            else if (hero is Spellblade && guild.Name != "WarriorGuild" && guild.Name != "SorcererGuild")
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guild.Name);
            }

            guild.RecruitHero(hero);

            return string.Format(OutputMessages.HeroRecruited, hero.Name, guild.Name);

        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attackerGuild = guilds.GetModel(attackerGuildName);
            IGuild defenderGuild = guilds.GetModel(defenderGuildName);

            if (attackerGuild == null || defenderGuild == null)
            {
                return OutputMessages.OneOfTheGuildsDoesNotExist;
            }

            if (attackerGuild.IsFallen || defenderGuild.IsFallen)
            {
                return OutputMessages.OneOfTheGuildsIsFallen;
            }

            int totalAttackerPower = 0;
            int totalDefenderPower = 0;

            foreach (var heroName in attackerGuild.Legion)
            {
                IHero hero = heroes.GetModel(heroName);
                totalAttackerPower += hero.Mana + hero.Stamina + hero.Power;
            }

            foreach (var heroName in defenderGuild.Legion)
            {
                IHero hero = heroes.GetModel(heroName);
                totalDefenderPower += hero.Mana + hero.Stamina + hero.Power;
            }

            if(totalAttackerPower > totalDefenderPower)
            {
                int loot = defenderGuild.Wealth;
                attackerGuild.WinWar(loot);
                defenderGuild.LoseWar();
                return string.Format(OutputMessages.WarWon, attackerGuild.Name, defenderGuild.Name, loot);
            }
            else
            {
                int loot = attackerGuild.Wealth;
                defenderGuild.WinWar(loot);
                attackerGuild.LoseWar();
                return string.Format(OutputMessages.WarLost, defenderGuild.Name, loot, attackerGuild.Name);
            }
        }

        public string TrainingDay(string guildName)
        {
            if (guilds.GetModel(guildName) == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            IGuild guild = guilds.GetModel(guildName);
            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guild.Name);
            }

            int trainingCost = guild.Legion.Count * 200;

            if (guild.Wealth < trainingCost)
            {
                return string.Format(OutputMessages.TrainingDayFailed, guild.Name);
            }

            List<string> legionNames = guild.Legion.ToList();
            ICollection<IHero> heroesToTrain = new List<IHero>();

            foreach (var heroName in legionNames)
            {
                heroesToTrain.Add(heroes.GetModel(heroName));
            }

            guild.TrainLegion(heroesToTrain);

            return string.Format(OutputMessages.TrainingDayStarted, guild.Name, guild.Legion.Count, trainingCost);
        }

        public string ValorState()
        {
            var sortedGuilds = guilds.GetAll()
                .OrderByDescending(g => g.Wealth); 

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Valor State:");

            foreach (var guild in sortedGuilds)
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                var heroesInGuild = new List<IHero>();

                foreach (var runeMark in guild.Legion)
                {
                    IHero hero = heroes.GetModel(runeMark);
                    if (hero != null)
                    {
                        heroesInGuild.Add(hero);
                    }
                }

                var sortedHeroes = heroesInGuild.OrderBy(h => h.Name); 

                foreach (var hero in sortedHeroes)
                {
                    sb.AppendLine($"-{hero.ToString()}");
                    sb.AppendLine($"--{hero.Essence()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
