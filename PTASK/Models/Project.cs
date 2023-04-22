
namespace PTASK.Models
{
    public class Project
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string mainProject { get; set; }
        public string background { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool status { get; set; }
        public string[] teamIds { get; set; }

        public IFormFile BackgroundFile { get; set; }
    }
}
