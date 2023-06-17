﻿using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            this.Types = new HashSet<Data.Models.Type>();
        }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<Data.Models.Type> Types { get; set; }
        public string? StartStr { get; set; }
        public string? EndStr { get; set; }
    }
}
