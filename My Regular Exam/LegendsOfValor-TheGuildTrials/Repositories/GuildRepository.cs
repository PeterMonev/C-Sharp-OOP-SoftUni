using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> guilds;

        public GuildRepository()
        {
            this.guilds = new List<IGuild>();
        }
        public void AddModel(IGuild entity)
        {
              this.guilds.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll() => this.guilds.AsReadOnly();


        public IGuild GetModel(string runeMarkOrGuildName)
        {
            return this.guilds.FirstOrDefault(g => g.Name == runeMarkOrGuildName);
        }
    }
}
