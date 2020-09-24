namespace MyPet.Application.MedicalRecords.Commands.Create
{
    public class CreateMedicalRecordOutputModel
    {
        public CreateMedicalRecordOutputModel(int medicalRecordId) 
            => this.MedicalRecordId = medicalRecordId;

        public int MedicalRecordId { get; }
    }
}
