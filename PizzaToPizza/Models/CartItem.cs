namespace PizzaToPizza.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = null!;

        public int Quantity { get; set; }
    }
}