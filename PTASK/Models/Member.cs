﻿using System.ComponentModel.DataAnnotations;

namespace PTASK.Models
{
    public class Member
    {
        public string _id { get; set; }
        public List<string> teamName { get; set; }
        public string position { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string createId { get; set; }
        public List<string> task { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập tên nhóm")]
        public List<string> memberIds { get; set; }
    }
}
