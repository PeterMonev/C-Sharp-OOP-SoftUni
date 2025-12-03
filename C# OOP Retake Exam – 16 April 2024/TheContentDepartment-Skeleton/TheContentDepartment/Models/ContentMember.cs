using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path) : base(name, path)
        {
            string[] allowedPaths = { "CSharp", "JavaScript", "Python", "Java" };
            if (!allowedPaths.Contains(path))
            {
                throw new ArgumentException($"{path} path is not valid.");
            }

        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Path} path. Currently working on {this.InProgress.Count} tasks.";
        }

    }
}
