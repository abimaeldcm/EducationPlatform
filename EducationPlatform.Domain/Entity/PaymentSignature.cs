using EducationPlatform.Domain.Entity.Enum;
using EducationPlatform.Domain.Entity.EntityRelational;

namespace EducationPlatform.Domain.Entity
{
    public class PaymentSignature
    {
        public int Id { get; set; }
        public DateTime ProcessingDate { get; set; }
        public EPaymentStatus Status { get; set; }
        public string Message { get; set; }
        public decimal Amount { get; set; }
        public string LinkPayment { get; set; }
        public string IdExternalPayment { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int IdUserSignature { get; set; }
        public UserSignature UserSignature { get; set; }
    }
}
