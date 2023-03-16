namespace PTASK.Models
{
    public class Project
    {
        public string _id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public bool status { get; set; }
        public List<string> roleIds { get; set; }
    }
}
