using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class Work
    {
        public string _id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string teamId { get; set; }
        public string leaderId { get; set; }
        public string createId { get; set; }
        public string projectId { get; set; }
        public List<string> teamName { get; set; }
    }
}
