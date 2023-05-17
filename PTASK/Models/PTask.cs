using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class PTask
    {
        public string _id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nhiệm vụ")]
        public string name { get; set; }
        public string description { get; set; }

        public string workName { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập tên công việc")]
        public string workId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        public DateTime startDay { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        public DateTime endDay { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public bool status { get; set; }
        public int level { get; set; }
        public List<infoMemberInTask> members { get; set; }

        [Required(ErrorMessage = "Vui lòng thêm thành viên")]
        public List<string> membersId { get; set; }
    }

    public class infoMemberInTask
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
    }
}
