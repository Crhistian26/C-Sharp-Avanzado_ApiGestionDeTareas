using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionTareas.Application.Interfaces
{
    public interface IJobServices
    {
        Task<JobDTO> AddJob(CreateJobDTO t);
        Task<JobDTO> UpdateJob(JobDTO t);
        Task DeleteJob(int id);
        Task<List<JobDTO>> GetAllJobs();
        Task<JobDTO> GetJob(int id);
    }
}
