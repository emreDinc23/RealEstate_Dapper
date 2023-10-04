namespace RealEstate_Dapper.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductAdress { get; set; }

        public int ProductCategory { get; set; }
        public string CategoryName { get; set; }

    }
}
