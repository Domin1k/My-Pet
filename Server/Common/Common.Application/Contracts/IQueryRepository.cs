namespace MyPet.Application.Contracts
{
    using Domain.Models;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
