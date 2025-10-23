
namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.age} years old.";
        }
    }
}
