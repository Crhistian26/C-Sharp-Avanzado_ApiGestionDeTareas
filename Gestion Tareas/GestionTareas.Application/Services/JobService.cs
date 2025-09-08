using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Application.Interfaces;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Exceptions;
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
        #region Privados para conversion
        private Job ConvertirDTOaEntidad(CreateJobDTO dto)
        {
            return new Job(
                dto.Title,
                dto.Description,
                dto.DueDate,
                dto.State,
                dto.AdditionalData
            );
        }

        private Job ConvertirDTOaEntidad(JobDTO dto)
        {
            return new Job(
                dto.Id,
                dto.Title,
                dto.Description,
                dto.DueDate,
                dto.State,
                dto.AdditionalData
            );
        }
        #endregion

        #region Delegados

        private static Func<CreateJobDTO,IJobRepository,Task> Comprobar =
        async (j,repo) =>
        {
            if (j.Title.Trim().Length < 6)
            {
                throw new AppException("La tarea debe de tener un titulo de minimo 6 caracteres sin espacio.");
            }

            if (j.Description.Trim().Length < 15)
            {
                throw new AppException("La tarea de debe tener una descripcion mas larga.");
            }

            if (j.DueDate < DateTime.Now)
            {
                throw new AppException("La tarea no puede ser para antes del momento actual.");
            }

            if (j.State != State.Pendiente)
            {
                throw new AppException("La tarea debe estar en el estado 'Pendiente' o 0.");
            }

            List<Job> list = await repo.GetAllJobs();
            if (list.Select(x => x.Title == j.Title).FirstOrDefault())
            {
                throw new AppException("Ya existe una tarea con ese titulo.");
            }
        };

        private static Action<JobDTO> AvisoDeCreacion =
        (j) =>
        {
            Console.WriteLine("Se creo con existo la tarea con el titulo de: " + j.Title);
        };

       

        #endregion

        public async Task<JobDTO> AddJob(CreateJobDTO j)
        {

            await Comprobar(j,_jobRepository);

            var job = ConvertirDTOaEntidad(j);

            var jobc = await _jobRepository.AddJob(job);

            var jobDTO = new JobDTO(jobc);

            AvisoDeCreacion(jobDTO);
            
            return jobDTO;
        }
        public async Task<JobDTO> UpdateJob(JobDTO j)
        {
            
            int id = j.Id;
            if (await _jobRepository.GetJob(id) == null)
            {
                throw new AppException("No existe una tarea con ese ID.");
            }

            var job = ConvertirDTOaEntidad(j);
            Job jobc = await _jobRepository.UpdateJob(job);

            var jobDTO = new JobDTO(jobc);

            return jobDTO;
        }
        public async Task DeleteJob(int id)
        {
            var j = await _jobRepository.GetJob(id);

            if(j == null)
            {
                throw new AppException("El id que registras no existe ya en la base de datos.");
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
