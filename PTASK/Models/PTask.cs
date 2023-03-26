namespace PTASK.Models
{
    public class PTask
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string workName { get; set; }
        public string imageLink { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public string status { get; set; }
        public List<Member> members { get; set; }
        public string[] linkSupports { get; set; }
    }

    public class Member
    {
        public string avatar { get; set; }
        public string name { get; set; }

    }
}
