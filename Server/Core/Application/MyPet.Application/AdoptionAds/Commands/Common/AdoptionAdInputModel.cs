namespace MyPet.Application.AdoptionAds.Commands.Common
{
    using MyPet.Application.Common;

    public class AdoptionAdInputModel : EntityCommand<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PublisherId { get; set; }

        public string CategoryName { get; set; }
    }
}
