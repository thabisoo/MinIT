using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.MeetingTypes
{
    public class MeetingTypeEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public IEnumerable<MeetingTypeEntity> MeetingTypes { get; set; }
    }
}
