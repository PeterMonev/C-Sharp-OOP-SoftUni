using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        private const double DefaultRanking = 15;
        private const double modifierRanking = 0.75;
        public AmateurManager(string name) : base(name, DefaultRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue * modifierRanking;
        }
    }
}
