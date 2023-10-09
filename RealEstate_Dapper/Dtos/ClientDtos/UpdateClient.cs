namespace RealEstate_Dapper.Dtos.ClientDtos
{
    public class UpdateClient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
