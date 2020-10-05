namespace MyPet.Application.Common.Contracts
{
    using MyPet.Domain.Common.Models;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
