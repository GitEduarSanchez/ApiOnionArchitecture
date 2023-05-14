namespace Application.Interfaces
{
    using Ardalis.Specification;

    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {

    }
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {

    }
}
