using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private readonly ResourceRepository resources;
        private readonly MemberRepository members;
        public Controller()
        {
            this.resources = new ResourceRepository();
            this.members = new MemberRepository();
        }
        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.Models.FirstOrDefault(r => r.Name == resourceName);

            if (!resource.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            TeamLead teamLead = members.Models.OfType<TeamLead>().FirstOrDefault();

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);

                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }
            else
            {
                resource.Test();
                return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
            }
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Workshop) && resourceType != nameof(Presentation))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }


            ContentMember member = members.Models
                .OfType<ContentMember>()
                .FirstOrDefault(x => x.Path == path);


            if (member == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (member.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource;

            if (resourceType == nameof(Exam))
            {
                resource = new Exam(resourceName, member.Name);
            }
            else if (resourceType == nameof(Workshop))
            {
                resource = new Workshop(resourceName, member.Name);
            }
            else
            {
                resource = new Presentation(resourceName, member.Name);
            }

            member.WorkOnTask(resourceName);
            resources.Add(resource);

            return $"{member.Name} created {resourceType} - {resourceName}.";
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Finished Tasks:");

            foreach (IResource resource in resources.Models.Where(r => r.IsApproved == true))
            {
                sb.AppendLine($"--{resource}");
            }

            TeamLead teamLead = members.Models.OfType<TeamLead>().FirstOrDefault();
            sb.AppendLine($"Team Report:");
            sb.AppendLine($"--{teamLead.Name} (TeamLead) - Currently working on {teamLead.InProgress.Count} tasks.");


            foreach (var member in members.Models.OfType<ContentMember>())
            {
                sb.AppendLine($"{member.Name} - {member.Path} path. Currently working on {member.InProgress.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(p => p.Path == path))
            {
                return OutputMessages.PositionOccupied;
            }

            if (members.Models.Any(m => m.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember newMember;

            if (memberType == nameof(TeamLead))
            {
                newMember = new TeamLead(memberName, path);
            }
            else
            {
                newMember = new ContentMember(memberName, path);
            }

            members.Add(newMember);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);

            if (member == null)
            {
                return OutputMessages.WrongMemberName;
            }

            IResource resource = resources.Models.Where(r => r.Creator == memberName && r.IsTested == false).OrderBy(r => r.Priority).FirstOrDefault();

            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            TeamLead teamLead = members.Models.OfType<TeamLead>().FirstOrDefault();
            member.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            resource.Test();

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }
    }
}
