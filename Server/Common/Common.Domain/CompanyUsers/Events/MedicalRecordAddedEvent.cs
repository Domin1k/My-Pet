namespace MyPet.Domain.CompanyUsers.Events
{
    using MyPet.Domain.Common.Events;
    using System;

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
