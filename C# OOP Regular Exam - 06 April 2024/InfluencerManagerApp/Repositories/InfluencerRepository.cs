using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> influencers;

        public InfluencerRepository()
        {
            this.influencers = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => influencers.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            if (model != null && !influencers.Contains(model))
                influencers.Add(model);
        }

        public IInfluencer FindByName(string username)
        {
            return influencers.FirstOrDefault(i => i.Username == username);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return influencers.Remove(model);
        }
    }
}
