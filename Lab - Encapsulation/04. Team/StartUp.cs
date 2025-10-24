using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Peter", "Petrov", 25, 1200),
                new Person("Georgi", "Ivanov", 45, 1500),
                new Person("Maria", "Dimitrova", 30, 2000),
                new Person("Kiril", "Stoyanov", 42, 1800)
            };

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
