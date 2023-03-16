namespace PTASK.Models
{
    public class Apis
    {
        private string api;
        public string ApiLogin
        {
            get { return api; }
            set { api = "https://ptask.cyclic.app/api/v1/auths/sign-in"; }
        }
        public string ApiGetAllProject
        {
            get { return api; }
            set { api = "https://ptask.cyclic.app/api/v1/projects"; }
        }
    }
}
