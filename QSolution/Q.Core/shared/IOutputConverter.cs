namespace Q.Core.shared
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
