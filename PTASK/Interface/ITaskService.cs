﻿using PTASK.Models;

namespace PTASK.Interface
{
    public interface ITaskService
    {
        Task<List<PTask>> GetAllTasks(string productId);
        Task<List<PTask>> GetTasksByWorkId(string workId);
        Task<List<PTask>> GetTaskByName(string name);
        Task<PTask> GetTaskById(string taskId);

        Task<bool> CreateTask(PTask task);
        Task<bool> UpdateTask(PTask task, string taskId);

        Task<bool> DeleteTask(string taskId);
        Task<bool> ChangeStatus(string taskId);
    }
}
