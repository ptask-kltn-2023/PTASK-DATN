using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class WorkCreate
    {
        [Required(ErrorMessage = "Vui lòng nhập tên công việc")]
        public string name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        public DateTime endTime { get; set; }
        public string createId { get; set; }
        public List<string> teamId { get; set; }
    }
}
