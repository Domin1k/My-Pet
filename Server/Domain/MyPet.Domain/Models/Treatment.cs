﻿namespace MyPet.Domain.Models
{
    using MyPet.Domain.Common;
    using MyPet.Domain.Exceptions;
    using System;

    public class Treatment : AuditableEntity<int>
    {
        public Treatment(string title, string description, string imageUrl, DateTime? next)
        {
            this.Validate(title, description, imageUrl, next);

            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Next = next;
        }

        public string Title { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public DateTime? Next { get; }

        public void Validate(string title, string description, string imageUrl, DateTime? next)
        {
            Guard.ForStringLength<InvalidTreatmentException>(
               title,
               ModelConstants.Treatment.MinTreatmentTitleLength,
               ModelConstants.Treatment.MaxTreatmentTitleLength,
               nameof(this.Title));

            Guard.ForValidUrl<InvalidTreatmentException>(
               imageUrl,
               nameof(this.ImageUrl));

            Guard.ForStringLength<InvalidTreatmentException>(
               description,
               ModelConstants.Common.Zero,
               ModelConstants.Treatment.MaxTreatmentDescriptionLength,
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
