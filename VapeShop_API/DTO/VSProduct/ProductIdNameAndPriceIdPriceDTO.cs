using VapeShop.Domain.VSProduct;

namespace VapeShop_API.DTO.VSProduct
{
    public class ProductIdNameAndPriceIdPriceDTO
    {
        public string ProductName { get; set; }
        public PriceChange priceChange { get; set; }
    }
}
