using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private string runeMark;
        private string guildName;
        private int power;
        private int mana;
        private int stamina;

        protected Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            this.Name = name;
            this.RuneMark = runeMark;
            this.Power = power;
            this.Mana = mana;
            this.Stamina = stamina;
        }

        public string Name
        {

            get { return name; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);
                }

                this.name = value;
            }
        }

        public string RuneMark
        {

            get { return runeMark; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
                }
                this.runeMark = value;
            }

        }

        public string GuildName
        {
            get { return guildName; }
            private set { this.guildName = value; }
        }

        public int Power
        {
            get { return power; }
            protected set { this.power = value; }
        }

        public int Mana
        {

            get { return mana; }
            protected set { this.mana = value; }
        }

        public int Stamina
        {
            get { return stamina; }
            protected set { this.stamina = value; }
        }

        public string Essence()
        {
            return $"Essence Revealed - Power [{this.Power}] Mana [{this.Mana}] Stamina [{this.Stamina}]";
        }

        public void JoinGuild(IGuild guild)
        {
            this.GuildName = guild.Name;
        }

        public abstract void Train();

        public override string ToString()
        {
            return $"Hero: [{this.Name}] of the Guild '{this.GuildName}' - RuneMark: {this.RuneMark}";
        }
    }
}
