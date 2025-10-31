using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations
{

    public class StartUp
    {

        static void Main(string[] args)
        {
            string commamd;
            List<IBirthable> list = new List<IBirthable>();

            while ((commamd = Console.ReadLine()) != "End")
            {
                string[] input = commamd.Split(" ");
                IBirthable birthable;

                switch (input[0])
                {

                    case "Citizen":
                        birthable = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                        list.Add(birthable);
                        break;
                    case "Pet":
                        birthable = new Pet(input[1], input[2]);
                        list.Add(birthable);
                        break;
                    case "Robot":
                        Robot robot = new Robot(input[1], input[2]);
                        break;
                    default:
                        break;

                }

            }

            string year = Console.ReadLine();

            foreach(IBirthable birthable1 in list)
            {
                if (birthable1.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthable1.Birthdate);
                }
            }
        }

    }



}

