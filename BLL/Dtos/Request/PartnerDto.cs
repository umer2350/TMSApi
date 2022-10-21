using System;
using System.Collections.Generic;

namespace BLL.Dtos.Request
{
    public class PartnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Image { get; set; }
        public string? DescriptionEnglish { get; set; }
        public string? DomainEnglish { get; set; }
        public string CompanyNameEnglish { get; set; }
        public string CompanyDetailEnglish { get; set; }
        public string? DescriptionSwedish { get; set; }
        public string? DomainSwedish { get; set; }
        public string CompanyNameSwedish { get; set; }
        public string CompanyDetailSwedish { get; set; }
    }
}
