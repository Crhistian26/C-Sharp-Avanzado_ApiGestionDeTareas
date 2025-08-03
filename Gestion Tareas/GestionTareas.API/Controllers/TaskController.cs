using GestionTareas.Application.DTOs.Jobs;
using GestionTareas.Application.Interfaces;
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

        public async Job<List<JobDTO>> GetAllJob()
        {
        }
    }
}
