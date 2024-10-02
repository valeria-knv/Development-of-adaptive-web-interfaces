using NodaTime;

namespace LR2
{
    public class ProductWithDate
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public LocalDateTime CreatedDate { get; set; }
    }
}
