using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository championship = new TeamRepository();

        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Ranking Table***");

            var sortedTeams = championship.Models
                .OrderByDescending(t => t.ChampionshipPoints)
                .ThenByDescending(t => t.PresentCondition);

            int position = 1;
            foreach (var team in sortedTeams)
            {
                sb.AppendLine($"{position}. {team}/{team.TeamManager}");
                position++;
            }

            return sb.ToString().TrimEnd();
        }




        public string JoinChampionship(string teamName)
        {
            if (championship.Models.Count == championship.Capacity)
            {
                return OutputMessages.ChampionshipFull;
            }
            if (championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }

            ITeam team = new Team(teamName);
            championship.Add(team);
            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {

            if (!this.championship.Exists(teamOneName) || !this.championship.Exists(teamTwoName))
            {
                return string.Format(OutputMessages.OneOfTheTeamDoesNotExist);
            }

            ITeam teamOne = this.championship.Get(teamOneName);
            ITeam teamTwo = this.championship.Get(teamTwoName);

            if (teamOne.PresentCondition == teamTwo.PresentCondition)
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);

                return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);

            }
            else
            {
                ITeam winner, looser;
                if (teamOne.PresentCondition > teamTwo.PresentCondition)
                {
                    winner = teamOne;
                    looser = teamTwo;
                }
                else
                {
                    winner = teamTwo;
                    looser = teamOne;
                }

                winner.GainPoints(3);

                if (winner.TeamManager != null)
                {
                    winner.TeamManager.RankingUpdate(5);
                }

                if (looser.TeamManager != null)
                {
                    looser.TeamManager.RankingUpdate(-5);
                }

                return string.Format(OutputMessages.TeamWinsMatch, winner.Name, looser.Name);
            }

        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(droppingTeamName))
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);

            if (championship.Exists(promotingTeamName))
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);

            ITeam newTeam = new Team(promotingTeamName);
            IManager newManager = null;

            bool managerExists = championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName);
            bool managerValid = managerTypeName == nameof(AmateurManager) ||
                                managerTypeName == nameof(SeniorManager) ||
                                managerTypeName == nameof(ProfessionalManager);

            if (!managerExists && managerValid)
            {
                if (managerTypeName == nameof(AmateurManager))
                    newManager = new AmateurManager(managerName);
                else if (managerTypeName == nameof(SeniorManager))
                    newManager = new SeniorManager(managerName);
                else
                    newManager = new ProfessionalManager(managerName);

                newTeam.SignWith(newManager);
            }

            foreach (var team in championship.Models)
                team.ResetPoints();

            championship.Remove(droppingTeamName);
            championship.Add(newTeam);

            return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }



        public string SignManager(string teamName, string managerTypeName, string managerName)
        {

            if (!championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }

            if (managerTypeName != nameof(AmateurManager) && managerTypeName != nameof(SeniorManager) && managerTypeName != nameof(ProfessionalManager))
            {
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }

            ITeam team = championship.Get(teamName);

            if (team.TeamManager != null)
            {
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
            }

            if (this.championship.Models.Any(t => t.TeamManager != null && t.TeamManager.Name == managerName))
            {
                return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
            }

            IManager manager;

            if (managerTypeName == nameof(AmateurManager))
            {
                manager = new AmateurManager(managerName);
            }
            else if (managerTypeName == nameof(SeniorManager))
            {
                manager = new SeniorManager(managerName);
            }
            else
            {
                manager = new ProfessionalManager(managerName);
            }

            team.SignWith(manager);


            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }
    }
}
