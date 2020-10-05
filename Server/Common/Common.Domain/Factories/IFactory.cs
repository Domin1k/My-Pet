namespace MyPet.Domain.Common.Factories
{
    using MyPet.Domain.Common.Models;

    public interface IFactory<out TEntity>
         where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
