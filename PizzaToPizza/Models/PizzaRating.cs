namespace PizzaToPizza.Models
{
    public class PizzaRating
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int Stars { get; set; }
    }
}