using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Id { get; private set; }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age 
        { 
            get { return age; } 
            private set { age = value; } 
        }

    }


}
