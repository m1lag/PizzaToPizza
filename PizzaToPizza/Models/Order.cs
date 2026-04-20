namespace PizzaToPizza.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; } = "Pending";

        public List<OrderItem> Items { get; set; }
            = new();
    }
}