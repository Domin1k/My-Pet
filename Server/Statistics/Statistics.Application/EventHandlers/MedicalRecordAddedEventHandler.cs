namespace MyPet.Application.Statistic.EventHandlers
{
    using MyPet.Application.Statistic;
    using MyPet.Domain.CompanyUsers.Events;
    using System.Threading.Tasks;
    using Contracts;

    public class MedicalRecordAddedEventHandler : IEventHandler<MedicalRecordAddedEvent>
    {
        private readonly IStatisticsQueryRepository statisticsRepository;

        public MedicalRecordAddedEventHandler(IStatisticsQueryRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public Task Handle(MedicalRecordAddedEvent domainEvent)
            => this.statisticsRepository.IncrementAdoptionAds();
    }
}
