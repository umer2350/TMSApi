using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BLL.Dtos
{
    public class MailRequestDto
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool HtmlAllowed { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
