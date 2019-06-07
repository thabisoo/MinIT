using MinIT.ApplicationLogic.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Interfaces.Services
{
    public interface IItemService
    {
        Task<ItemEntity> AddItemAsync(ItemEntity meetingItemEntity);

        Task<ItemEntity> EditMeetingItemAsync(ItemEntity meetingItemEntity);

        Task<ItemEntity> EditMeetingItemStatusAsync(ItemEntity meetingItemEntity);

        ItemEntity GetMeetingItemAsync(Guid Id);

        IEnumerable<ItemEntity> GetPreviousMeetingItemsAsync(Guid meetingTypeId);

        ItemEntity GetAllItemsForMeetingAsync(Guid meetingId);

        ItemHistoryEntity GetItemHistory(Guid id); 
    }
}
