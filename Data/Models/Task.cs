using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? WorkerId { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public int? StatusId { get; set; }
        public string Notes { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
