namespace MyPet.Domain
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IDomainRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
