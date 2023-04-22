namespace PTASK.Models
{
    public class Team
    {
        public string _id { get; set; }
        public string teamName { get; set; }
        public string leaderName { get; set; }
        public List<string> workName { get; set; }
        public List<members> listMembers { get; set; }
        public string createId { get; set; }
        public string leaderId { get; set; }
        public List<string> listTeams { get; set; }
        public string projectId { get; set; }
        public bool status { get; set; }

    }

    public class members
    {
        public string id { get; set; }
        public string fullName { get; set; }
    }
}
