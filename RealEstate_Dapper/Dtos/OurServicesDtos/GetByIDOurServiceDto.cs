﻿namespace RealEstate_Dapper.Dtos.OurServicesDtos
{
    public class GetByIDOurServiceDto
    {
        public int OurServiceID { get; set; }
        public string OurServiceTitle { get; set; }
        public string OurServiceDescription { get; set; }
        public string OurServiceIcon { get; set; }
    }
}
