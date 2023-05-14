namespace Persistence.Repository
{
    using Application.Interfaces;
    using Ardalis.Specification.EntityFrameworkCore;
    using Persistence.EntityFrameworkCore.ApplicationContext;

    public class Repository<T> : RepositoryBase<T>, IReadRepositoryAsync<T> where T : class
    {
        private readonly ApplicationContext applicationContext;

        public Repository(ApplicationContext applicationContext):base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
