using Newtonsoft.Json;
using NuGet.Protocol;
using PTASK.Interface;
using PTASK.Models;

namespace PTASK.Reponsitory
{
    public class RProject : IProject
    {
        Apis api = new Apis();
        public Project Create(Project project)
        {
            throw new NotImplementedException();
        }

        public Project Delete(int project)
        {
            throw new NotImplementedException();
        }

        public Project FindProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> List()
        {
            api.ApiGetAllProject = "api";
            var data = new List<Project>();
            try
            {
                using (var client = new HttpClient())
                {
                    var res = client.GetStringAsync(api.ApiGetAllProject);
                    res.Wait();
                    data = JsonConvert.DeserializeObject<Project[]>(res.Result).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public Project Update(Project product)
        {
            throw new NotImplementedException();
        }
    }
}
