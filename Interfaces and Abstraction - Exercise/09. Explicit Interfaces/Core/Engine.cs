using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Core
{

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader
                = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string command;
            List<Citizen> citizens = new List<Citizen>();

            while ((command = reader.ReadLine()) != "End")
            {
                string[] input = command.Split(" ");
                Citizen citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                citizens.Add(citizen);
            }

            foreach (Citizen citizen in citizens)
            {
                writer.WriteLine(((IPerson)citizen).GetName());
                writer.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
