﻿using System.ComponentModel.DataAnnotations;

namespace OmegaSample.Models
{
    public class PagingOptions
    {
        [Range(1, 9999, ErrorMessage = "Offset must be greater than 0.")]
        public int? Offset { get; set; }

        [Range(1, 100, ErrorMessage = "Limit must be greater than 0 and less than 100.")]
        public int? Limit { get; set; }
    }
}
