using a = Q.Entities;
using t = System.Threading.Tasks;
using System.Collections.Generic;

namespace Q.Core.Contracts
{
    public interface ITaskRepository
    {
        t.Task Add(a.Task task);
        t.Task Update(a.Task task);

        t.Task Delete(a.Task task);

        t.Task<List<a.Task>> GetTasks(); 
    }
}
