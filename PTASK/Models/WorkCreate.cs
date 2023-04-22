namespace PTASK.Models
{
    public class WorkCreate
    {
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string createId { get; set; }
        public List<string> teamId { get; set; }
        public string projectId { get; set; }
        public string leaderId { get; set; }
    }
}
