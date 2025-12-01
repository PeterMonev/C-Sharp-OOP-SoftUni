using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        private const double DefaultRanking = 30;
        public SeniorManager(string name) : base(name, DefaultRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue;
        }
    }
}
