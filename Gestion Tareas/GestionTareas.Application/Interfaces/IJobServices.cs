using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Jobs;

namespace GestionTareas.Application.Interfaces
{
    public interface IJobServices
    {
        Task<JobDTO> AddJob(CreateJobDTO t);
        void UpdateJob(JobDTO t);
        void DeleteJob(int id);
        Task<List<JobDTO>> GetAllJobs();
        Task<JobDTO> GetJob(int id);
        Task<List<JobDTO>> GetJobForDate(DateTime begin, DateTime end);
        Task<List<JobDTO>> GetJobForState(State state);
    }
}
