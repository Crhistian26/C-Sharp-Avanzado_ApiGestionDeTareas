using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Application.Interfaces;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _taskServices;

        public JobController(IJobServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {
            var jobs = await _taskServices.GetAllJobs();
            Console.WriteLine(jobs.First().Title);
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(int id)
        {
            var job = await _taskServices.GetJob(id);
            if (job == null)
            {
                throw new APIException("No hay una tarea con ese ID.");
            }
            Console.WriteLine(job.Title);
            return Ok(job);

        }

        [HttpPost]
        public async Task<ActionResult<JobDTO>> AddJob(CreateJobDTO job)
        {
            var createdJob = await _taskServices.AddJob(job);
            return CreatedAtAction(nameof(GetJob), new {id = createdJob.Id}, createdJob);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobDTO>> UpdateJob(int id, JobDTO job)
        {
            if (id != job.Id)
            {
                throw new APIException("El ID de la tarea no coincide con el ID ingresado.");
            }

            var updatedJob = await _taskServices.UpdateJob(job);

            return Ok(updatedJob);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _taskServices.DeleteJob(id);
            return NoContent();
        }

    }
}
