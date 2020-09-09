namespace MyPet.Domain.Factories
{
    using MyPet.Domain.Common;

    public interface IFactory<out TEntity>
         where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
