using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private const double MinValue = 0;
        private const double MaxValue = 100;

        private string name;
        private double ranking;
        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }

                this.name = value;
            }
        }

        public double Ranking
        {

            get { return this.ranking; }
            protected set
            {
                if (value < MinValue)
                {
                     this.ranking = MinValue;
                }
                else if (value > MaxValue)
                {
                     this.ranking = MaxValue;
                } else
                {
                    this.ranking = value;
                }
            }
        }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }

    }
}
