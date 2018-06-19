using Microsoft.EntityFrameworkCore;
using Q.Core.Contracts;
using Q.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using obj = Q.Entities;

namespace Q.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(obj.Task task)
        {
            _context.Entry(task).State = EntityState.Added;
            await _context.Tasks.AddAsync(task);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task Delete(obj.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<obj.Task>> GetTasks()
        {
            return await Task.Run(() => _context.Tasks.ToList());
        }

        public async Task Update(obj.Task task)
        {
            _context.Entry(task).State = EntityState.Added;

            int affectedRows = await _context.SaveChangesAsync();
        }
    }
}
