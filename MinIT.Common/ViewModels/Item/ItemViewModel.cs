using MinIT.Common.ViewModels.Meeting;
using MinIT.Common.ViewModels.MeetingItemStatus;
using MinIT.Common.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Common.ViewModels.Item
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid ItemStatusId { get; set;}

        public string Description { get; set; }

        public string Comment { get; set; }

        public string Heading
        {
            get
            {
                return $"Minutes ({Meeting?.Number}) - {Meeting?.DateTime.DateTime}";
            }
        }

        public DateTimeOffset DueDate { get; set; }

        public MeetingViewModel Meeting { get; set; }

        public UserViewModel User { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<MeetingItemStatusViewModel> MeetingItemStatuses { get; set; }
    }
}
