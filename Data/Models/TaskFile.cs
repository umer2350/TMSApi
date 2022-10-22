using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class TaskFile
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string FileName { get; set; }
    }
}
