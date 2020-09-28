namespace MyPet.Domain.MedicalRecords.Factories.Nested
{
    using MyPet.Domain.MedicalRecords.Models;
    using System;

    public class TreatmentFactory
    {
        private string title;
        private string description;
        private string imageUrl;
        private DateTime? next;

        public TreatmentFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public TreatmentFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public TreatmentFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public TreatmentFactory WithNextDate(DateTime? next)
        {
            this.next = next;
            return this;
        }

        public Treatment Build()
        {
            return new Treatment(this.title, this.description, this.imageUrl, this.next);
        }
    }
}
