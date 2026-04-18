using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class CreatePromoCodeDto
    {
        [Required]
        public string Code { get; set; } = "";

        [Range(1, 100)]
        public decimal DiscountPercent { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}