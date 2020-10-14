namespace MyPet.Application.MedicalRecords.Queries.Search
{
    using MediatR;
    using MyPet.Application.MedicalRecords.Queries.Common;
    using MyPet.Domain.MedicalRecords.Specifications;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class MedicalRecordSearchQuery : PageModel, IRequest<IEnumerable<MedicalRecordSearchOutputModel>>
    {
        public string AnimalName { get; set; }

        public class MedicalRecordSearchQueryHandler : IRequestHandler<MedicalRecordSearchQuery, IEnumerable<MedicalRecordSearchOutputModel>>
        {
            private readonly IMedicalRecordQueryRepository medicalRecordQueryRepository;

            public MedicalRecordSearchQueryHandler(IMedicalRecordQueryRepository medicalRecordQueryRepository) 
                => this.medicalRecordQueryRepository = medicalRecordQueryRepository;

            public async Task<IEnumerable<MedicalRecordSearchOutputModel>> Handle(MedicalRecordSearchQuery request, CancellationToken cancellationToken)
                => await this
                        .medicalRecordQueryRepository
                        .GetMedicalRecords(
                            new MedicalRecordByNameSpecification(request.AnimalName),
                            new MedicalRecordSortOrder(request.SortBy, request.Order),
                            skip: (request.Page) * RecordsPerPage,
                            take: RecordsPerPage,
                            cancellationToken);
        }
    }
}
