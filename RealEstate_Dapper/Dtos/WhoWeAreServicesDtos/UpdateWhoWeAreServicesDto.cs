﻿namespace RealEstate_Dapper.Dtos.WhoWeAreServicesDtos
{
    public class UpdateWhoWeAreServicesDto
    {
        public int StatusID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
