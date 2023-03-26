namespace PTASK.Models
{
    public class User
    {
        public string email { get; set;}
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string fullName { get; set; }
        public DateTime birthday { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public int gender { get; set; }
        public string avatarImage { get; set; }
    }
}
