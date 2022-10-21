using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Request
{
    public class JoinDto
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string FileName { get; set; }
        public string CoverFileName { get; set; }
        public string CoverText { get; set; }
        public int JobId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
