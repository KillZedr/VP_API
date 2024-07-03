namespace VapeShop_API.DTO.VSProduct
{
    public class CreateProductDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string PicturePath { get; set; }

        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }

        public decimal Price { get; set; }
    }
}
