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

        public async void DeleteJob(Job j)
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
            return await _context.Jobs.FindAsync(id); 
            
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<List<Job>> GetJobForDate(DateTime begin, DateTime end)
        {
            return await _context.Jobs.Where(j => j.DueDate <= end && j.DueDate >= begin).ToListAsync();
        }
        public async Task<List<Job>> GetJobForState(State state)
        {
            return await _context.Jobs.Where(j => j.State == state).ToListAsync();
        }

        
    }
}
