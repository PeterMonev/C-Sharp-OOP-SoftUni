using ExplicitInterfaces.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../output.txt";
            using StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(line);
        }
    }
}
