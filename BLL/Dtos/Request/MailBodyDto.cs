using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Request
{
    public class MailBodyDto
    {
        public string Type { get; set; }
        public string Language { get; set; }
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public string ApplicantName { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string EmailBody { get; set; }
        public string Subject { get; set; }
    }
}
