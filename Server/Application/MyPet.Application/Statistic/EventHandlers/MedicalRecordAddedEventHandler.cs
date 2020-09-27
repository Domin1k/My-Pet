namespace MyPet.Application.Statistic.EventHandlers
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Application.Statistic;
    using MyPet.Domain.CompanyUsers.Events;
    using System.Threading.Tasks;

    public class MedicalRecordAddedEventHandler : IEventHandler<MedicalRecordAddedEvent>
    {
        private readonly IStatisticsQueryRepository statisticsRepository;

        public MedicalRecordAddedEventHandler(IStatisticsQueryRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public Task Handle(MedicalRecordAddedEvent domainEvent)
            => this.statisticsRepository.IncrementAdoptionAds();
    }
}
