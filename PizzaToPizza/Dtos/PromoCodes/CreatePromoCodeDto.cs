using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class CreatePromoCodeDto
    {
        public int UserId { get; set; }

        [Required]
        public string Code { get; set; } = "";

        [Range(1, 100)]
        public int DiscountPercent { get; set; }

        public int? PizzaId { get; set; }

        public DateTime? ExpiryDate { get; set; }

    }
}