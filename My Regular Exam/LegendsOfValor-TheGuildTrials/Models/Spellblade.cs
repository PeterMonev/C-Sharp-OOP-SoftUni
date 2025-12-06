using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        private const int DefaultPower = 50;
        private const int DefaultMana = 60;
        private const int DefaultStamina = 60;
        public Spellblade(string name, string runeMark) : base(name, runeMark, DefaultPower, DefaultMana, DefaultStamina)
        {
        }

        public override void Train()
        {
            this.Power += 15;
            this.Stamina += 10;
            this.Mana += 10;
        }
    }
}
