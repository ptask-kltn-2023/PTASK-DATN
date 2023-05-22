using PTASK.Models;

namespace PTASK.Interface
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentByIdTask(string taskId);
        Task<List<Comment>> GetCommentByIdWork(string workId);
        Task<Comment> CreateCommentWork(Comment comment);
        Task<Comment> CreateCommentTask(Comment comment);
    }
}