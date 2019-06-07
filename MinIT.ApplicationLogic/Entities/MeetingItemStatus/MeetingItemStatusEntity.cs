using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.MeetingItemStatus
{
    public class MeetingItemStatusEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public IEnumerable<MeetingItemStatusEntity> MeetingItemStatuses { get; set; }
    }
}
