using MinIT.Common.ViewModels.MeetingType;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Common.ViewModels.Meeting
{
    public class MeetingViewModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }

        public IEnumerable<Guid> CarriedOverItemIds { get; set; }

        public MeetingTypeViewModel MeetingType { get; set; }

        public IEnumerable<MeetingViewModel> Meetings { get; set; }

        public IEnumerable<MeetingTypeViewModel> MeetingTypes { get; set; }
    }
}
