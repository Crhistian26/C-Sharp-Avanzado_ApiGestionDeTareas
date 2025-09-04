using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GestionTareas.Domain.Exceptions;

namespace GestionTareas.Infraestructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobContext _context;

        public JobRepository(JobContext context)
        {
            _context = context;
        }

        public async Task<Job> AddJob(Job j)
        {
            _context.Jobs.Add(j);
            await _context.SaveChangesAsync();
            return j;
        }

        public async Task DeleteJob(int id)
        {
            var j = await GetJob(id);
            if (j == null)
            {
                throw new InfraestructureException("Error de infraestructura: No hay tareas con ese ID.");
            }

            _context.Jobs.Remove(j);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJob(Job j)
        {
            _context.Jobs.Remove(j);
            await _context.SaveChangesAsync();
        }

        public async Task<Job> UpdateJob(Job j)
        {
            _context.Jobs.Update(j);
            await _context.SaveChangesAsync();
            return j;
        }

        public async Task<Job> GetJob(int id)
        {
            Job j = await _context.Jobs.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
            if (j == null)
            {
                throw new InfraestructureException("Error de infraestructura: No hay tareas con ese ID.");
            }

            return j;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }
        
    }
}
