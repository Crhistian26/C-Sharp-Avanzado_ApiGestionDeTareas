using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> AddJob(Job j);
        Task<Job> UpdateJob(Job j);
        Task DeleteJob(int id);
        Task DeleteJob(Job j);
        Task<List<Job>> GetAllJobs();
        Task<Job> GetJob(int id);
    }
}
