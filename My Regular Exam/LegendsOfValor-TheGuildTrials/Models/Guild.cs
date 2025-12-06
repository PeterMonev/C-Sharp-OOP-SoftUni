using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string name;
        private int wealth = 5000;
        private bool isFallen = false;
        private readonly List<string> legion;

        public Guild(string name)
        {
            this.Name = name;
            this.legion = new List<string>();
        }

        public string Name
        {

            get { return this.name; }
            private set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                {
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                }
                this.name = value;
            }
        }

        public int Wealth
        {

            get { return this.wealth; }
            private set
            {
               this.wealth =  Math.Max(0, value);
            }
        }

        public IReadOnlyCollection<string> Legion => this.legion.AsReadOnly();

        public bool IsFallen
        {

            get { return this.isFallen; }
            private set
            {
                this.isFallen = value;
            }
        }

        public void LoseWar()
        {
            this.IsFallen = true;
            this.Wealth = 0;
        }

        public void RecruitHero(IHero hero)
        {
            if (this.IsFallen)
            {
                return;
            }

            if (this.Wealth >= 500)
            {
                hero.JoinGuild(this);
                this.legion.Add(hero.RuneMark);
                this.Wealth -= 500;
            }
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            if (this.IsFallen)
                return;

            int totalCost = heroesToTrain.Count * 200;
            if (this.Wealth < totalCost) return;

            foreach (var hero in heroesToTrain)
            {
                hero.Train();
            }
            this.Wealth -= totalCost;
        }


        public void WinWar(int goldAmount)
        {
            this.Wealth += goldAmount;
        }
    }
}
