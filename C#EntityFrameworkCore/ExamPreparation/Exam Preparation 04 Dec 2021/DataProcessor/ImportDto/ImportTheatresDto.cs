﻿using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatresDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }
        public ImportTicketsDto[] Tickets { get; set; }
    }
}
