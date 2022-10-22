using System;

namespace BLL.Dtos
{
    public class TaskDto
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
    }
}
