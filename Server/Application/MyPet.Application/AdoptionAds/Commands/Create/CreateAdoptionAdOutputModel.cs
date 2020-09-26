namespace MyPet.Application.AdoptionAds.Commands.Create
{
    public class CreateAdoptionAdOutputModel
    {
        public CreateAdoptionAdOutputModel(int adoptionAdId) 
            => AdoptionAdId = adoptionAdId;

        public int AdoptionAdId { get; }
    }
}
