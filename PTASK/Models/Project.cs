using PTASK.Extensions;
using System.ComponentModel.DataAnnotations;
namespace PTASK.Models
{
    public class Project
    {
        [Key]
        public string _id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên dự án")]
        public string name { get; set; }
        public string mainProject { get; set; }
        public string background { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        [StartEndDateValidation("endTime", ErrorMessage = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc")]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        public DateTime endTime { get; set; }
        public bool status { get; set; }
        public string mainName { get; set; }
        public IFormFile BackgroundFile { get; set; }
    }
}
