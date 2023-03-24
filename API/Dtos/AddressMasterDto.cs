﻿namespace API.Dtos
{
    public class AddressMasterDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? AddressFor { get; set; }
        public int? CompanyDetailId { get; set; }
    }
}
