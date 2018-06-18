using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Q.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task Add(Entities.Task task);
        Task Update(Entities.Task task);

        Task Delete(Entities.Task task);

        Task<List<Entities.Task>> GetTasks(); 
    }
}
