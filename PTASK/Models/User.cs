﻿namespace PTASK.Models
{
    public class User
    {
        public string _id { get; set; }
        public string fullName { get; set; }
        public DateTime birthday { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public bool gender { get; set; }
        public bool status { get; set; }
        public string avatar { get; set; }
        public string accountId { get; set; }

        public IFormFile AvartarFile { get; set; }
    }
}
