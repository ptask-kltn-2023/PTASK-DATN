﻿using PTASK.Models;

namespace PTASK.Interface
{
    public interface IWorkService
    {
        Task<List<Work>> GetAllWorkByIdProject(string projectId);
        Task<bool> CreateWork(Work work);
    }
}