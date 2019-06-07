using MinIT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinIT.Domain.Models
{
    public class MeetingItemStatus : ITimestamp
    {
        public Guid ItemId { get; set; }

        public Guid ItemStatusId { get; set; }

        [Required]
        public virtual ItemStatus ItemStatus { get; set; }

        [Required]
        public virtual Item Item { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
