using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicle vehicleFactory;
        private IVehiclesFactory vehiclesFactory;

        public Engine(IReader reader, IWriter writer, IVehicle vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public Engine(IReader reader, IWriter writer, IVehiclesFactory vehiclesFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehiclesFactory = vehiclesFactory;
        }

        public void Run()
        {
            
                List<IVehicle> vehicles = new List<IVehicle>();

                string[] token = reader.ReadLine().Split(" ");
                IVehicle newVehicle = vehiclesFactory.Create(token[0], double.Parse(token[1]), double.Parse(token[2]));
                vehicles.Add(newVehicle);

                token = reader.ReadLine().Split(" ");
                newVehicle = vehiclesFactory.Create(token[0], double.Parse(token[1]), double.Parse(token[2]));
                vehicles.Add(newVehicle);

                int n = int.Parse(reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] commands = reader.ReadLine().Split(" ");

                    string command = commands[0];
                    string type = commands[1];
                    double km = double.Parse(commands[2]);

                    IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                    if (command == "Drive")
                    {
                    writer.WriteLine(vehicle.Drive(km));

                    }
                    else if (command == "Refuel")
                    {

                        vehicle.Refuel(km);
                    }

                }
                foreach (IVehicle vehicle in vehicles)
                {
                    writer.WriteLine(vehicle.ToString());
                }

        }
    }
}
