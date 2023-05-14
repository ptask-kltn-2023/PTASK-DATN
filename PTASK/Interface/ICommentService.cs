using PTASK.Models;

namespace PTASK.Interface
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentByIdTask(string taskId);
        Task<List<Comment>> GetCommentByIdWorl(string workId);
        Task<bool> CreateCommentWork(Comment comment);
        Task<bool> CreateCommentTask(Comment comment);
    }
}
