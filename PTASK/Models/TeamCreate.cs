using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class TeamCreate
    {
        public string createId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhóm")]
        public string teamName { get; set; }

        [Required(ErrorMessage = "Vui lòng thêm trưởng nhóm")]
        public string leaderId { get; set; }

        [Required(ErrorMessage = "Vui lòng thêm thành viên")]
        public List<string> listMembers { get; set; }
        public List<string> listTeams { get; set; }

        public string projectId { get; set; }

        public bool status { get; set; }

    }
}
