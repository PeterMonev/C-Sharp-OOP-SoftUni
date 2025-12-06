using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        private const int DefaultPower = 40;
        private const int DefaultMana = 120;
        private const int DefaultStamina = 0;
        public Sorcerer(string name, string runeMark) : base(name, runeMark, DefaultPower, DefaultMana, DefaultStamina)
        {
        }

        public override void Train()
        {
            this.Power += 20;
            this.Mana += 25;
        }
    }
}
