using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private string path;
        private readonly List<string> names;

        protected TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            this.names = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                this.name = value;
            }
        }

        public string Path
        {
            get { return path; }
            protected set { this.path = value; }
        }

        public IReadOnlyCollection<string> InProgress => this.names;

        public void FinishTask(string resourceName)
        {
            if (names.Contains(resourceName))
            {
                names.Remove(resourceName);
            }
        }

        public void WorkOnTask(string resourceName)
        {
            this.names.Add(resourceName);
        }
    }
}
