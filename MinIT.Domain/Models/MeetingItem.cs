using MinIT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinIT.Domain.Models
{
    public class MeetingItem : ITimestamp
    {
        public Guid MeetingId { get; set; }

        public Guid ItemId { get; set; }

        [Required]
        public virtual Meeting Meeting { get; set; }

        [Required]
        public virtual Item Item { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}


