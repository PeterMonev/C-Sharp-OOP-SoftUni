
namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public string Name
        {
            get { return this.name; }

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot cantain fewer than 3 symbols.");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Person> FirstTeam { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return this.firstTeam.AsReadOnly(); }  }

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                this.firstTeam.Add(person);
            } else
            {
                this.reserveTeam.Add(person);
            }
        }
    }

}
