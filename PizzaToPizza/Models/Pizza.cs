namespace PizzaToPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public string Image { get; set; } = "";

        public double RatingAverage { get; set; }

        public int RatingCount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
