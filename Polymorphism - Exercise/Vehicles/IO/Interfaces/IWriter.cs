using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string line);
        void WriteLine(IVehicle vehicle);
    }
}
