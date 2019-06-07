using Microsoft.Extensions.Configuration;
using MinIT.ApplicationLogic.Entities.Items;
using MinIT.ApplicationLogic.Entities.MeetingItemStatus;
using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Entities.Users;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Domain;
using MinIT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<MeetingItem> _meetingItemRepository;
        private readonly IBaseRepository<Meeting> _meetingRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<ItemStatus> _itemStatusRepository;
        private readonly IBaseRepository<MeetingItemStatus> _meetingItemStatusRepository;
        private readonly IConfiguration _configuration;

        public ItemService(IBaseRepository<Item> itemRepository,
            IBaseRepository<MeetingItem> meetingItemRepository,
            IBaseRepository<Meeting> meetingRepository,
            IBaseRepository<User> userRepository,
            IBaseRepository<ItemStatus> itemStatusRepository,
            IBaseRepository<MeetingItemStatus> meetingItemStatusRepository,
            IConfiguration configuration)
        {
            _itemRepository = itemRepository;
            _meetingItemRepository = meetingItemRepository;
            _meetingRepository = meetingRepository;
            _userRepository = userRepository;
            _itemStatusRepository = itemStatusRepository;
            _meetingItemStatusRepository = meetingItemStatusRepository;
            _configuration = configuration;
        }

        public async Task<ItemEntity> AddItemAsync(ItemEntity meetingItemEntity)
        {
            var item = new Item
            {
                UserId = meetingItemEntity.UserId,
                Description = meetingItemEntity.Description,
                DueDate = meetingItemEntity.DueDate,
                ItemStatusId = _itemStatusRepository.All().FirstOrDefault().Id,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _itemRepository.Add(item);
            await _itemRepository.SaveAsync();

            var meetingItem = new MeetingItem
            {
                MeetingId = meetingItemEntity.Meeting.Id,
                ItemId = item.Id,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _meetingItemRepository.Add(meetingItem);
            await _meetingItemRepository.SaveAsync();

            return new ItemEntity
            {
                Id = item.Id,
                Description = item.Description,
                DueDate = item.DueDate,
                UserId = item.UserId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Meeting = new MeetingEntity
                {
                    Id = item.MeetingItem.MeetingId
                }
            };
        }

        public async Task<ItemEntity> EditMeetingItemAsync(ItemEntity meetingItemEntity)
        {
            var item = _itemRepository.Where(i => i.Id == meetingItemEntity.Id).FirstOrDefault();

            item.UserId = meetingItemEntity.UserId;
            item.Description = meetingItemEntity.Description;
            item.DueDate = meetingItemEntity.DueDate;
            item.Comment = meetingItemEntity.Comment;
            item.UpdatedAt = DateTimeOffset.Now;

            _itemRepository.Update(item);
            await _itemRepository.SaveAsync();

            return new ItemEntity
            {
                Id = item.Id,
                Description = item.Description,
                DueDate = item.DueDate,
                UserId = item.UserId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Meeting = new MeetingEntity
                {
                    Id = meetingItemEntity.Meeting.Id
                }
            };
        }

        public async Task<ItemEntity> EditMeetingItemStatusAsync(ItemEntity meetingItemEntity)
        {
            var item = _itemRepository.Where(i => i.Id == meetingItemEntity.Id).FirstOrDefault();

            item.ItemStatusId = _itemStatusRepository
                .Where(s => s.Id == meetingItemEntity.ItemStatusId).FirstOrDefault().Id;

            _itemRepository.Update(item);
            await _itemRepository.SaveAsync();

            var meetingItem = new MeetingItemStatus
            {
                ItemId = item.Id,
                ItemStatusId = item.ItemStatusId,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _meetingItemStatusRepository.Add(meetingItem);
            await _meetingItemStatusRepository.SaveAsync();

            return new ItemEntity
            {
                Id = item.Id,
                Description = item.Description,
                DueDate = item.DueDate,
                UserId = item.UserId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }

        public ItemEntity GetAllItemsForMeetingAsync(Guid meetingId)
        {
            var items = _itemRepository.Where(i => i.MeetingItem.MeetingId == meetingId);

            return new ItemEntity
            {
                Items = items.Select(i => new ItemEntity
                {
                    Id = i.Id,
                    User = _userRepository.Where(u => u.Id == i.UserId).Select(e => new UserEntity
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    }).FirstOrDefault(),
                    DueDate = i.DueDate,
                    Description = i.Description,
                    Comment = i.Comment
                }),
                Meeting = _meetingRepository.Where(m => m.Id == meetingId).Select(m => new MeetingEntity
                {
                    Id = m.Id,
                    DateTime =  m.DateTime,
                    Number = m.Number,
                }).FirstOrDefault(), 
                Users = _userRepository.All().Select(u => new UserEntity
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }),
                MeetingItemStatuses = _itemStatusRepository.Where(s => s.IsDeleted == false)
                .Select(e => new MeetingItemStatusEntity
                {
                    Id = e.Id,
                    Name = e.Name
                })
            };
        }
    
        public ItemEntity GetMeetingItemAsync(Guid Id)
        {
            var meetingItem = _itemRepository.Where(i => i.Id == Id).FirstOrDefault();

            return new ItemEntity
            {
                Id = meetingItem.Id,
                Description = meetingItem.Description,
                DueDate = meetingItem.DueDate,
                UserId = meetingItem.UserId,
                Comment = meetingItem.Comment,
                ItemStatusId = meetingItem.ItemStatusId
            };
        }

        public IEnumerable<ItemEntity> GetPreviousMeetingItemsAsync(Guid meetingTypeId)
        {
            var previousMeeting = _meetingRepository.Where(m => m.MeetingTypeId == meetingTypeId).LastOrDefault();
            var previousItems = _itemRepository.Where(i => i.MeetingItem.MeetingId == previousMeeting.Id);
          
            return previousItems.Select(i => new ItemEntity
            {
                Id = i.Id,
                Description = i.Description,
                User = _userRepository.Where(u => u.Id == i.UserId).Select(e => new UserEntity
                {
                    FirstName = i.User.FirstName,
                    LastName = i.User.LastName
                }).FirstOrDefault()
            });
        }

        public ItemHistoryEntity GetItemHistory(Guid id)
        {
            var item = _itemRepository.Where(i => i.Id == id).FirstOrDefault();

            return new ItemHistoryEntity
            {
                Item = new ItemEntity
                {
                    Description = item.Description,
                    DueDate = item.DueDate,
                    User = _userRepository.Where(u => u.Id == item.UserId).Select(i => new UserEntity
                    {
                        Id = i.Id,
                        FirstName = i.FirstName,
                        LastName = i.LastName
                    }).FirstOrDefault()
                },
                ItemHistories = _meetingItemStatusRepository.Where(mi => mi.ItemId == id).Select(i => new ItemHistoryEntity
                {
                    Status = _itemStatusRepository.Where(s => s.Id == i.ItemStatusId).FirstOrDefault().Name,
                    UpdatedAt = i.UpdatedAt
                })
            };
        }
    }
}
