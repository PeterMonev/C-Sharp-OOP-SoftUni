using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;

        }

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        public string Id
        {
            get; private set;
        }
    }
}
