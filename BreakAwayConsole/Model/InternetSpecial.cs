﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InternetSpecial
    {
        public int InternetSpecialId { get; set; }
        public int Nights { get; set; }
        public decimal CostUSD { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        [ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }
        [ForeignKey("Accommodation")]
        public Lodging Accommodation { get; set; }
    }
}
