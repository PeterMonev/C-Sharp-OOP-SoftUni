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
        private readonly Models.Interfaces.Vehicle vehicleFactory;
        private IVehiclesFactory vehiclesFactory;

        public Engine(IReader reader, IWriter writer, Models.Interfaces.Vehicle vehicleFactory)
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

            List<Models.Interfaces.Vehicle> vehicles = new List<Models.Interfaces.Vehicle>();

            string[] token = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Models.Interfaces.Vehicle newVehicle = vehiclesFactory.Create(token[0], double.Parse(token[1]), double.Parse(token[2]), double.Parse(token[3]));
            vehicles.Add(newVehicle);

            token = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            newVehicle = vehiclesFactory.Create(token[0], double.Parse(token[1]), double.Parse(token[2]), double.Parse(token[3]));
            vehicles.Add(newVehicle);

            token = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            newVehicle = vehiclesFactory.Create(token[0], double.Parse(token[1]), double.Parse(token[2]), double.Parse(token[3]));
            vehicles.Add(newVehicle);


            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string type = commands[1];
                double km = double.Parse(commands[2]);

                Models.Interfaces.Vehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                if (command == "Drive")
                {
                    writer.WriteLine(vehicle.Drive(km));

                }
                else if (command == "Refuel")
                {

                    string refuelMessage = vehicle.Refuel(km);

                    if(refuelMessage != "Refueld")
                    {
                        writer.WriteLine(refuelMessage);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    if (vehicle is ISpecializedVehicle)
                    { 
                        writer.WriteLine(((ISpecializedVehicle)vehicle).DriveEmpty(km));
                    }
                }

            }
            foreach (Models.Interfaces.Vehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }

        }
    }
}
