namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Exceptions;
    using System;

    public class Treatment : Entity<int>
    {
        internal Treatment(string title, string description, string imageUrl, DateTime? next)
        {
            this.Validate(title, description, imageUrl, next);

            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Next = next;
        }

        private Treatment(string title, string description, string imageUrl)
        {
            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        public DateTime? Next { get; private set; }

        public void Validate(string title, string description, string imageUrl, DateTime? next)
        {
            Guard.ForStringLength<InvalidTreatmentException>(
               title,
               MedicalRecordConstants.Treatment.MinTreatmentTitleLength,
               MedicalRecordConstants.Treatment.MaxTreatmentTitleLength,
               nameof(this.Title));

            Guard.ForValidUrl<InvalidTreatmentException>(
               imageUrl,
               nameof(this.ImageUrl));

            Guard.ForStringLength<InvalidTreatmentException>(
               description,
               ModelConstants.Common.Zero,
               MedicalRecordConstants.Treatment.MaxTreatmentDescriptionLength,
               nameof(this.Description));

            if (next.HasValue)
            {
                if (next.Value < DateTime.UtcNow.AddDays(-1))
                {
                    throw new InvalidTreatmentException($"Next treatment date cannot be date from the past");
                }
            }
        }
    }
}
