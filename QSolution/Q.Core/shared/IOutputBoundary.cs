namespace Q.Core.shared
{
    public interface IOutputBoundary<T>
    {
        T Output { get; }
        void Populate(T response);
    }
}
