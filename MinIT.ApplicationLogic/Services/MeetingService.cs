using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Entities.MeetingTypes;
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
    public class MeetingService : IMeetingService
    {
        private readonly IBaseRepository<Meeting> _meetingRepository;
        private readonly IBaseRepository<MeetingType> _meetingTypeRepository;
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<MeetingItem> _meetingItemRepository;

        public MeetingService(IBaseRepository<Meeting> meetingRepository,
            IBaseRepository<MeetingType> meetingTypeRepository,
            IBaseRepository<Item> itemRepository,
            IBaseRepository<MeetingItem> meetingItemRepository)
        {
            _meetingRepository = meetingRepository;
            _meetingTypeRepository = meetingTypeRepository;
            _itemRepository = itemRepository;
            _meetingItemRepository = meetingItemRepository;
        }

        public async Task<MeetingEntity> CreateMeetingAsync(CreateMeetingEntity createMeetingEntity) 
        {
            var meetingType = _meetingTypeRepository.Where(mt => mt.Id == createMeetingEntity.MeetingTypeId).FirstOrDefault().Name;
            var numOfMeetings = _meetingRepository.Where(m => m.MeetingTypeId == createMeetingEntity.MeetingTypeId).Count();

            var meeting = new Meeting
            {
                MeetingTypeId = createMeetingEntity.MeetingTypeId,
                DateTime = createMeetingEntity.DateTime,
                Number = $"{meetingType.Substring(0,1)}{numOfMeetings + 1}",
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _meetingRepository.Add(meeting);
            await _meetingRepository.SaveAsync();

            await AddCarriedOverItems(meeting, createMeetingEntity);

            return new MeetingEntity
            {
                Id = meeting.Id,
                DateTime = meeting.DateTime,
                CreatedAt = meeting.CreatedAt,
                UpdatedAt = meeting.UpdatedAt
            };
        }

        public MeetingEntity GetAllMeetingsAsync()
        {
            var meetings = _meetingRepository.All().OrderBy(m => m.DateTime);

            return new MeetingEntity
            {
                MeetingTypes = _meetingTypeRepository.All().Select(mt => new MeetingTypeEntity { Id = mt.Id, Name = mt.Name}),
                Meetings = meetings.Select(m => new MeetingEntity
                {
                    Id = m.Id,
                    Number = m.Number,
                    MeetingType = _meetingTypeRepository.Where(mt => mt.Id == m.MeetingTypeId).Select(a => new MeetingTypeEntity
                    {
                        Id = a.Id,
                        Name = a.Name,
                        IsDeleted = a.IsDeleted,
                        CreatedAt = a.CreatedAt.ToString(),
                        UpdatedAt = a.UpdatedAt.ToString()
                    }).FirstOrDefault(),

                    DateTime = m.DateTime,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt
                })
            };
        }

        private async Task AddCarriedOverItems(Meeting meeting, CreateMeetingEntity createMeetingEntity)
        {
            if (createMeetingEntity.CarriedOverItemIds != null)
            {
                foreach (var id in createMeetingEntity.CarriedOverItemIds)
                {
                    var currentStatus = _itemRepository.Where(i => i.Id == id).FirstOrDefault().ItemStatusId;

                    var meetingItem = new MeetingItem
                    {
                        MeetingId = meeting.Id,
                        ItemId = id,
                    };

                    _meetingItemRepository.Add(meetingItem);
                    await _meetingItemRepository.SaveAsync();

                };
            }
        }
    }
}
