﻿using System.ComponentModel.DataAnnotations;

namespace Afro.Ranking.Domain.Model
{
    public class GeoLocationViewModel
    {
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
    }
}
