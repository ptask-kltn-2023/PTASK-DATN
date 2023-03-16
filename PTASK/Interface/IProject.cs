using PTASK.Models;

namespace PTASK.Interface
{
    public interface IProject
    {
        List<Project> List();
        Project Create(Project project);
        Project Update(Project project);
        Project FindProjectById(int id);
        Project Delete(int product);
    }
}
