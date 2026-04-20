namespace PizzaToPizza.Dtos
{
    public class UpdatePromoCodeDto
    {
        public string Code { get; set; } = "";
        public int DiscountPercent { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}