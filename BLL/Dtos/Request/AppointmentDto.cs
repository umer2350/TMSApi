using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Request
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string AppointmentWith { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Agenda { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Body { get; set; }
    }
}
