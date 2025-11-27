using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
     
        }

        public string FullName { get; private set; }

        [MyRange(12, 90)]
        public int Age {  get; private set; }
    }
}
