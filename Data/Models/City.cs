﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
    }
}
