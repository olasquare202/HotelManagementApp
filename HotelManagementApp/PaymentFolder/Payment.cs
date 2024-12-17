using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementApp.PaymentFolder
{
    public class Payment
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public enum PaymentMethod { Card, Transfer, Cash}
        public PaymentMethod PaymentMeth { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal Amount { get; set; }
    }
}
