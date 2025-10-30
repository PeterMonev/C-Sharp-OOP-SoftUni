using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System.Diagnostics.Metrics;

namespace BorderControl { 

    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<IIdentifiable> society = new List<IIdentifiable>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                IIdentifiable identifiable;

                if (input.Length == 3)
                {
                    identifiable = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    society.Add(identifiable);

                }
                else if(input.Length == 2)
                {
                    identifiable = new Robot(input[0], input[1]);
                    society.Add(identifiable);

                }

            }

            string fakeId = Console.ReadLine();

            foreach(IIdentifiable identifiable in society)
            {
             
                if (identifiable.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
