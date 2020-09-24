namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using System.Collections.Generic;

    public abstract class TreatmentsOutputModel<TTreatmenetOutputModel>
    {
        internal TreatmentsOutputModel(
            IEnumerable<TTreatmenetOutputModel> treatments,
            int page,
            int totalPages)
        {
            this.Treatments = treatments;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TTreatmenetOutputModel> Treatments { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
