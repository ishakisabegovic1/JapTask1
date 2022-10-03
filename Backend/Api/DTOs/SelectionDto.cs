﻿using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class SelectionDto
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int JapId { get; set; }
        public string Jap { get; set; }
    }
}
