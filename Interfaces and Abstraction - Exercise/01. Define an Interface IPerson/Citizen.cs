using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public string Name { get { return name; } private set { name = value; } }

        public int Age { get { return age; } private set { age = value; } }

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
