using MedLedger.Domain.Common;

namespace MedLedger.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
