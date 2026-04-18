namespace PizzaToPizza.Dtos
{
    public class UpdatePizzaDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}