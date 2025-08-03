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

        //Metodos para ahorrar lineas de codigo:
        #region Metodos
        private Job _convertirCreateDTOaEntidad(CreateJobDTO createJobDTO)
        {
            return new Job(createJobDTO.Description, createJobDTO.DueDate, createJobDTO.State, createJobDTO.AdditionalData);
        }
        private Job _convertirDTOaEntidad(JobDTO jobDTO)
        {
            return new Job(jobDTO.Id, jobDTO.Description, jobDTO.DueDate, jobDTO.State, jobDTO.AdditionalData);
        }
        private JobDTO _convertirCreateDTOaEntityDTO(int id, CreateJobDTO createJobDTO)
        {
            return new JobDTO(id, createJobDTO.Description, createJobDTO.DueDate, createJobDTO.State, createJobDTO.AdditionalData);
        }

        private JobDTO _convertirEntityaEntityDTO(Job job)
        {
            return new JobDTO(job.Id, job.Description, job.DueDate, job.State, job.AdditionalData);
        }
        #endregion
        public async Task<JobDTO> AddJob(CreateJobDTO j)
        {
            var job = _convertirCreateDTOaEntidad(j);

            var jobc = await _jobRepository.AddJob(job);

            var jobDTO = _convertirEntityaEntityDTO(jobc);
            
            return jobDTO;
        }
        public async Task<JobDTO> UpdateJob(JobDTO j)
        {
            var job = _convertirDTOaEntidad(j);

            var jobc = await _jobRepository.UpdateJob(job);

            var jobDTO = _convertirEntityaEntityDTO(jobc);

            return jobDTO;
        }
        public async void DeleteJob(int id)
        {
            var j = _jobRepository.GetJob(id);

            if(j == null)
            {
                throw new Exception("El id que registras no existe ya en la base de datos.");
            }

            await _jobRepository.DeleteJob(j);

        }
        public async Task<List<JobDTO>> GetAllJobs()
        {
            return await _jobRepository.GetAllJobs(); 
        }
        public async Task<JobDTO> GetJob(int id)
        {
            return null;
        }
        public async Task<List<JobDTO>> GetJobForDate(DateTime begin, DateTime end)
        {
            return null;
        }
        public async Task<List<JobDTO>> GetJobForState(State state)
        {
            return null;
        }
    }
}
