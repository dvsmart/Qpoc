using System.Threading.Tasks;

namespace Q.Core.shared
{
    public interface IInputBoundary<T>
    {
        Task Process(T input);
    
    }
}
