using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var allTypes = typeof(Tracker).Assembly.GetTypes();

            foreach (var type in allTypes)
            {
                var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (var method in methods)
                {
                var authorAtrribute = method.GetCustomAttributes<AuthorAttribute>().Where(attr => attr != null).Select(attr => attr.Name).ToList();

                    if (authorAtrribute.Any())
                    {
                        Console.WriteLine($"{method.Name} is written by {string.Join(", " authorAtrribute)}");
                    }

                }
            }
        }
    }
}
