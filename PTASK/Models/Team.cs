using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class Team
    {
        public string _id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nhóm")]
        public string teamName { get; set; }

        public string leaderName { get; set; }
        public List<string> workName { get; set; }

        [Required(ErrorMessage = "Vui lòng thêm thành viên")]
        public List<members> listMembers { get; set; }

        [Required(ErrorMessage = "Vui lòng thêm trưởng nhóm")]
        public string leaderId { get; set; }
    }

    public class members
    {
        public string id { get; set; }
        public string fullName { get; set; }
    }
}
