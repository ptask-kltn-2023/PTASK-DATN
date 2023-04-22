namespace PTASK.Models
{
    public class Auth
    {
        public string email { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string confirmPassword { get; set; }

        public DateTime birthday { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public bool gender { get; set; }
        public bool status { get; set; }

        public IFormFile avatar { get; set; }

    }
}
