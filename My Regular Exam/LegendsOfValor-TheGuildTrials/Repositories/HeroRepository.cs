using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }
        public void AddModel(IHero entity)
        {
            heroes.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll() => this.heroes.AsReadOnly();


        public IHero GetModel(string runeMarkOrGuildName)
        {
            return heroes.FirstOrDefault(h => h.RuneMark == runeMarkOrGuildName);

        }
    }
}
