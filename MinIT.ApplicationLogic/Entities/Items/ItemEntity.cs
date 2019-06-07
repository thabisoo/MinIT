using MinIT.ApplicationLogic.Entities.MeetingItemStatus;
using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.Items
{
    public class ItemEntity
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid ItemStatusId { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public MeetingEntity Meeting { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public UserEntity User { get; set; }

        public IEnumerable<ItemEntity> Items { get; set; }

        public IEnumerable<UserEntity> Users { get; set; }

        public IEnumerable<MeetingItemStatusEntity> MeetingItemStatuses { get; set; }
    }

    public class ItemHistoryEntity
    {
        
        public string Status { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public ItemEntity Item { get; set; }

        public IEnumerable<ItemHistoryEntity> ItemHistories { get; set; }
    }
}
