namespace MyPet.Application.MedicalRecords.Commands.Common
{
    using MyPet.Application.Common;

    public abstract class MedicalRecordInputModel : EntityCommand<int>
    {
        public string AnimalName { get; set; }

        public int AnimalAge { get; set; }

        public string AnimalBreedName { get; set; }

        public string AnimalSpecies { get; set; }
    }
}
