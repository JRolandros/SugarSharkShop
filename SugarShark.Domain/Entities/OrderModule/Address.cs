﻿
namespace SugarShark.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}