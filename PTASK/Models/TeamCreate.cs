namespace PTASK.Models
{
    public class TeamCreate
    {
        public string createId { get; set; }
        public string teamName { get; set; }
        public string leaderId { get; set; }
        public List<string> listMembers { get; set; }
        public List<string> listTeams { get; set; }

        public string projectId { get; set; }

        public bool status { get; set; }

    }
}
