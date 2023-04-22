namespace PTASK.Models
{
    public class DetailProject
    {
        public Project Project { get; set; }
        public List<Work> Works { get; set; }
        public List<Member> Members { get; set; }
        public List<PTask> PTasks { get; set; }
    }
}
