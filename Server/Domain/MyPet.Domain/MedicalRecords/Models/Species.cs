namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;

    public class Species : Enumeration
    {
        public static readonly Species Dog = new Species(1, nameof(Dog));
        public static readonly Species Cat = new Species(2, nameof(Cat));
        public static readonly Species Bird = new Species(3, nameof(Bird));
        public static readonly Species Fish = new Species(4, nameof(Fish));

        private Species(int value, string name)
            : base(value, name)
        {
        }
    }
}
