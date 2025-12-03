using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private string creator;
        private int priority;
        private bool isTested = false;
        private bool isApproved = false;

        protected Resource(string name, string creator, int priority)
        {
            this.Name = name;
            this.Creator = creator;
            this.Priority = priority;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public string Creator
        {
            get { return creator; }
            private set { this.creator = value; }
        }

        public int Priority
        {
            get { return priority; }
            private set { this.priority = value; }
        }

        public bool IsTested
        {
            get { return isTested; }
            private set { isTested = value; }
        }

        public bool IsApproved
        {
            get { return isApproved; }
            private set { isApproved = value; }
        }

        public void Approve()
        {
            this.IsApproved = true;
        }

        public void Test()
        {
            this.IsTested = !this.IsTested;
        }

        public override string ToString()
        {
            return $"{this.Name} ({GetType().Name}), Created By: {this.Creator}";
        }
    }
}
