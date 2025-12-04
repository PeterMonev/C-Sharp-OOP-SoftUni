using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private double budget;
        List<string> contributors;

        protected Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            this.contributors = new List<string>();
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }

                this.brand = value;
            }
        }

        public double Budget
        {
            get { return this.budget; }
            private set { this.budget = value; }
        }

        public IReadOnlyCollection<string> Contributors => this.contributors;

        public void Engage(IInfluencer influencer)
        {
            if(this.budget >= influencer.CalculateCampaignPrice() && !this.contributors.Contains(influencer.Username))
            {
            this.contributors.Add(influencer.Username);
            this.budget -= influencer.CalculateCampaignPrice();
            }
        }

        public void Gain(double amount)
        {
            this.budget += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
        }
    }
}
