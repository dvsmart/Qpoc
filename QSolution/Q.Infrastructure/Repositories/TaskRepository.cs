using Microsoft.EntityFrameworkCore;
using Q.Core.Entities;
using Q.Core.Interfaces;
using Q.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async System.Threading.Tasks.Task Add(Core.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Added;
            await _context.Tasks.AddAsync(task);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(Core.Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Core.Entities.Task>> GetTasks()
        {
            return await System.Threading.Tasks.Task.Run(() => _context.Tasks.ToList());
        }

        public async System.Threading.Tasks.Task Update(Core.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Added;

            int affectedRows = await _context.SaveChangesAsync();
        }
    }
}
