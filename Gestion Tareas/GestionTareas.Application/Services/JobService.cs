using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Application.Interfaces;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Application.Services
{
    public class JobService : IJobServices
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository job) => _jobRepository = job;
        public Job ConvertirDTOaEntidad(CreateJobDTO dto)
        {
            return new Job(
                dto.Description,
                dto.DueDate,
                dto.State,
                dto.AdditionalData
            );
        }

        public Job ConvertirDTOaEntidad(JobDTO dto)
        {
            return new Job(
                dto.Id,
                dto.Description,
                dto.DueDate,
                dto.State,
                dto.AdditionalData
            );
        }

        public async Task<JobDTO> AddJob(CreateJobDTO j)
        {

            var job = ConvertirDTOaEntidad(j);
            var jobc = await _jobRepository.AddJob(job);

            var jobDTO = new JobDTO(jobc);

            return jobDTO;
        }
        public async Task<JobDTO> UpdateJob(JobDTO j)
        {
            var job = ConvertirDTOaEntidad(j);

            var jobc = await _jobRepository.UpdateJob(job);

            var jobDTO = new JobDTO(jobc);

            return jobDTO;
        }
        public async Task DeleteJob(int id)
        {
            var j = _jobRepository.GetJob(id);

            if(j == null)
            {
                throw new Exception("El id que registras no existe ya en la base de datos.");
            }

            await _jobRepository.DeleteJob(id);

        }
        public async Task<List<JobDTO>> GetAllJobs()
        {
            var list = await _jobRepository.GetAllJobs();
            var nlist = list.Select(x => new JobDTO(x)).ToList();
            return nlist; 
        }

        public async Task<JobDTO> GetJob(int id)
        {
            return new JobDTO(await _jobRepository.GetJob(id));
        }
    }
}
