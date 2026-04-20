namespace PizzaToPizza.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = "";

        public decimal Total { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public List<string> Items { get; set; } = new();
    }
}