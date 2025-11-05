using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
             Console.WriteLine(line);
        }

        public void WriteLine(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
