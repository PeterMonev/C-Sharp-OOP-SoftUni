using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private const int DefaultCapacity = 10;
        private readonly List<ITeam> teams;
        public IReadOnlyCollection<ITeam> Models
        {
            get;

        }
        public int Capacity { get; } = DefaultCapacity;

        public TeamRepository()
        {
            this.teams = new List<ITeam>();
            this.Models = this.teams.AsReadOnly();
        }

        public void Add(ITeam model)
        {
            if (this.teams.Count < this.Capacity)
            {
                this.teams.Add(model);
            }
        }

        public bool Exists(string name)
        {
          return this.teams.Any(teams => teams.Name == name);
        }

        public ITeam Get(string name)
        {
            return this.teams.FirstOrDefault(t => t.Name == name);
        }

        public bool Remove(string name)
        {
            return this.teams.RemoveAll(t => t.Name == name) > 0;
        }
    }
}
