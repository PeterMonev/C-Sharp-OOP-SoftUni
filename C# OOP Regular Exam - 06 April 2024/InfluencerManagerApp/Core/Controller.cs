using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private readonly InfluencerRepository influencers;
        private readonly CampaignRepository campaigns;

        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();


            List<IInfluencer> sortedInfulencers = influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers).ToList();

            foreach (var influencer in sortedInfulencers)
            {
                sb.AppendLine(influencer.ToString());

                var activeCampaigns = campaigns.Models.Where(c => influencer.Participations.Contains(c.Brand)).OrderBy(c => c.Brand).ToList();

                if (activeCampaigns.Any())
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campaign in activeCampaigns)
                    {
                        sb.AppendLine($"--{campaign}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (!influencers.Models.Any(i => i.Username == username))
            {
                return string.Format(OutputMessages.InfluencerNotFound, "InfluencerRepository", username);
            }

            if (!campaigns.Models.Any(i => i.Brand == brand))
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            IInfluencer influencer = influencers.Models.FirstOrDefault(i => i.Username == username);

            if (influencer.Participations.Contains(brand))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            ICampaign campaign = campaigns.Models.FirstOrDefault(c => c.Brand == brand);

            if (campaign is ProductCampaign && !(influencer is BusinessInfluencer || influencer is FashionInfluencer))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);

            }

            if (campaign is ServiceCampaign && !(influencer is BusinessInfluencer || influencer is BloggerInfluencer))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            campaign.Engage(influencer);
            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);


            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.Models.Any(c => c.Brand == brand))
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign;

            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand);
            }
            else
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.Models.FirstOrDefault(c => c.Brand == brand);

            if (campaign == null)
            {
                return OutputMessages.InvalidCampaignToClose;
            }

            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencer in influencers.Models.Where(i => i.Participations.Contains(brand)))
            {
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);

            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.Models.FirstOrDefault(i => i.Username == username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Any())
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);

            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.Models.FirstOrDefault(c => c.Brand == brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund, brand);
            }

            if (amount <= 0)
            {
                return (OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer) && typeName != nameof(FashionInfluencer) && typeName != nameof(BloggerInfluencer))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.Models.Any(i => i.Username == username))
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, influencers.GetType().Name);
            }

            IInfluencer influencer;

            if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}
