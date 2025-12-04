using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private readonly List<ICampaign> campaigns;

        public CampaignRepository()
        {
            this.campaigns = new List<ICampaign>();
        }
        public IReadOnlyCollection<ICampaign> Models => this.campaigns;

        public void AddModel(ICampaign model)
        {
            this.campaigns.Add(model);
        }

        public ICampaign FindByName(string name)
        {
            return this.campaigns.FirstOrDefault(c => c.Brand == name);
        }

        public bool RemoveModel(ICampaign model)
        {
            return this.campaigns.Remove(model);
        }
    }
}
