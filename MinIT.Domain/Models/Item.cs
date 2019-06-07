using MinIT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Domain.Models
{
    public class Item :  ITimestamp
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid ItemStatusId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public string Comment { get; set; }

        public virtual User User { get; set; }

        public virtual MeetingItem MeetingItem { get; set; }

        public virtual ItemStatus ItemStatus { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}



