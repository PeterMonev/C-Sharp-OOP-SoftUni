using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Citizen : INameable, IIdentifiable, IBirthable
    {
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        { get; private set; }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
