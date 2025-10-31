using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Citizen : INameable, IAgeable, IBuyer
    {
        private string id;
        private string birthdate;

        public Citizen(string name, string age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }
        public string Name
        {
            get; private set;
        }

        public string Age
        {
            get; private set;
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
            private set { birthdate = value; }
        }

        public int Food
        {
            get; private set;
        }

        public void BuyFood()
        {
            Food += 10;
        }

    }

}
