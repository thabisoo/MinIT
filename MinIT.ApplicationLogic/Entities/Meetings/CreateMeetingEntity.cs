using MinIT.ApplicationLogic.Entities.MeetingTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.Meetings
{
    public class CreateMeetingEntity
    {
        public Guid MeetingTypeId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public IEnumerable<Guid> CarriedOverItemIds { get; set; }
    }

    public class MeetingEntity
    {
        public Guid Id { get; set; }

        public MeetingTypeEntity MeetingType { get; set; }

        public string Type { get; set; }

        public string Number { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public IEnumerable<MeetingTypeEntity> MeetingTypes { get; set; }

        public IEnumerable<MeetingEntity> Meetings { get; set; }
    }
}
