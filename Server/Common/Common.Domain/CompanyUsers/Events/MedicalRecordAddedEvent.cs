namespace MyPet.Domain.CompanyUsers.Events
{
    using System;
    using Domain.Events;

    public class MedicalRecordAddedEvent : IDomainEvent
    {
        public MedicalRecordAddedEvent(int medicalRecordId)
        {
            this.MedicalRecordId = medicalRecordId;
            this.OccurredOn = DateTime.UtcNow;
        }

        public int MedicalRecordId { get; }

        public DateTime OccurredOn { get; }
    }
}
