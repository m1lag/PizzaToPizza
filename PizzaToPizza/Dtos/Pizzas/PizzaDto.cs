namespace PizzaToPizza.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public double RatingAverage { get; set; }
        public int RatingCount { get; set; }

        public string Image { get; set; } = "";

        public string Category { get; set; } = "";
    }
}