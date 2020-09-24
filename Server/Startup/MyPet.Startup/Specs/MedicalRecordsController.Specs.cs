namespace MyPet.Startup.Specs
{
    using FluentAssertions;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Web.MedicalRecords;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class MedicalRecordsControllerSpecs
    {
        [Theory]
        [InlineData(1, 5)]
        public void Details_ShouldReturnDetailsOutputWhenIdExists(int id, int totalTreatments)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/MedicalRecords/{id}")
                .To<MedicalRecordsController>(c => c.Details(new MedicalRecordDetailsQuery { Id = id }))
                .Which(instance => instance
                    .WithData(MedicalRecordFakes.Data.GetMedicalRecord(id, totalTreatments)))
                .ShouldReturn()
                .ActionResult<MedicalRecordDetailsOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.AnimalAge.Should().BeGreaterThan(0);
                        model.AnimalName.Should().NotBeNullOrEmpty();
                        model.Treatments.Should().HaveCount(totalTreatments);
                    }));
    }
}
