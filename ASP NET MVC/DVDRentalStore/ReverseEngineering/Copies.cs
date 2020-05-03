﻿using System;
using System.Collections.Generic;

namespace DVDRentalStore.ReverseEngineering
{
    public partial class Copies
    {
        public Copies()
        {
            Rentals = new HashSet<Rentals>();
        }

        public int CopyId { get; set; }
        public bool? Available { get; set; }
        public int? MovieId { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
