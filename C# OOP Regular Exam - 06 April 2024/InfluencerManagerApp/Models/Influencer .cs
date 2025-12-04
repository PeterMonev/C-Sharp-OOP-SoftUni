using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private double engagementRate;
        private double income = 0;
        private List<string> participations;

        protected Influencer(string username, int followers, double engagementRate)
        {
            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.participations = new List<string>();
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }

                this.username = value;
            }
        }

        public int Followers
        {

            get { return this.followers; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }

                this.followers = value;
            }

        }

        public double EngagementRate
        {
            get { return this.engagementRate; }
            private set { this.engagementRate = value; }
        }

        public double Income
        {
            get { return this.income; }
            private set { this.income = value; }
        }

        public IReadOnlyCollection<string> Participations => this.participations;

        public abstract int CalculateCampaignPrice();
        
        public void EarnFee(double amount)
        {
            this.Income += amount;
        }

        public void EndParticipation(string brand)
        {
            bool endParticipation = this.participations.Any(b => b == brand);

            if (endParticipation == false)
            {
                this.participations.Remove(brand);
            }
        }

        public void EnrollCampaign(string brand)
        {
            this.participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
