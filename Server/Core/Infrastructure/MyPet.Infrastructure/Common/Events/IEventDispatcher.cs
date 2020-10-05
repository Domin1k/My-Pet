namespace MyPet.Infrastructure.Common.Events
{
    using MyPet.Domain.Common.Events;
    using System.Threading.Tasks;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
