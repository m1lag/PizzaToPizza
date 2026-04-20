namespace PizzaToPizza.Models
{
    public class PromoCode
    {
        public int Id { get; set; }

        public string Code { get; set; } = "";

        public int DiscountPercent { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public bool IsUsed { get; set; } = false;

        public DateTime ExpiryDate { get; set; }
    }
}