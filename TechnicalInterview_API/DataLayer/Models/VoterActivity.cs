﻿namespace TechnicalInterview_API.DataLayer.Models
{
    public class VoterActivity
    {
        public int VoterId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DistrictId { get; set; }
        public string? Address { get; set; }
        public string? AddressUnit { get; set; }
        public int StatusId { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
