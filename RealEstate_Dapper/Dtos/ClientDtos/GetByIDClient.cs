namespace RealEstate_Dapper.Dtos.ClientDtos
{
    public class GetByIDClient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
