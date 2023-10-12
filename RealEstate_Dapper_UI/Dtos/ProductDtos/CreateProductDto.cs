namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
       
        public string productTitle { get; set; }
        public decimal productPrice { get; set; }
        public string productCity { get; set; }
        public string productDistrict { get; set; }
        public string productCoverImage { get; set; }
        public string productAdress { get; set; }
        public string Type { get; set; }

        public string categoryID { get; set; }

    }
}
