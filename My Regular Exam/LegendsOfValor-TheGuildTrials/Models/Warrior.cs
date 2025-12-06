using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        private const int DefaultPower = 60;
        private const int DefaultMana = 0;
        private const int DefaultStamina = 100;
        public Warrior(string name, string runeMark) : base(name, runeMark, DefaultPower, DefaultMana, DefaultStamina)
        {
        }

        public override void Train()
        {
            this.Power += 30;
            this.Stamina += 10;
        }
    }
}
