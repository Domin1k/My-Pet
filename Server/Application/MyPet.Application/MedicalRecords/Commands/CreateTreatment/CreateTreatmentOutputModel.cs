namespace MyPet.Application.MedicalRecords.Commands.CreateTreatment
{
    public class CreateTreatmentOutputModel
    {
        public CreateTreatmentOutputModel(int medicalRecordId) 
            => MedicalRecordId = medicalRecordId;

        public int MedicalRecordId { get; }
    }
}
