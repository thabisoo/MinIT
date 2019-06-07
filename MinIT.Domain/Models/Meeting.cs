using MinIT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Domain.Models
{
    public class Meeting :  ITimestamp
    {
        public Guid Id { get; set; }

        public Guid MeetingTypeId { get; set; }

        public string Number { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public virtual MeetingType MeetingType { get; set; }

        public virtual MeetingItem MeetingItem { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
