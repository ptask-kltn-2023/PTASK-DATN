namespace PTASK.Models
{
    public class PTask
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string workName { get; set; }
        public string workId { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public bool status { get; set; }
        public int level { get; set; }
        public List<infoMemberInTask> members { get; set; }
        public List<string> membersId { get; set; }
    }

    public class infoMemberInTask
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
    }
}
