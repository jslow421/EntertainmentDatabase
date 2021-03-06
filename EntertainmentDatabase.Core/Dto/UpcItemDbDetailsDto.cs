﻿using System.Collections.Generic;

namespace EntertainmentDatabase.Core.Dto
{
    public class UpcItemDbDetailsDto
    {
        public string Title { get; set; }
        public string Ean { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}