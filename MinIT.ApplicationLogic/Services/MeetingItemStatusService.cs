using MinIT.ApplicationLogic.Entities.MeetingItemStatus;
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
    public class MeetingItemStatusService : IMeetingItemStatusService
    {
        private readonly IBaseRepository<ItemStatus> _meetingItemStatusRepository;

        public MeetingItemStatusService(IBaseRepository<ItemStatus> meetingItemStatusRepository)
        {
            _meetingItemStatusRepository = meetingItemStatusRepository;
        }

        public async Task<MeetingItemStatusEntity> AddMeetingItemStatusAsync(MeetingItemStatusEntity meetingTypeEntity)
        {
            var meetingItemStatus = new ItemStatus
            {
                Name = meetingTypeEntity.Name,
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _meetingItemStatusRepository.Add(meetingItemStatus);
            await _meetingItemStatusRepository.SaveAsync();

            return new MeetingItemStatusEntity
            {
                Id = meetingItemStatus.Id,
                Name = meetingItemStatus.Name,
                IsDeleted = meetingItemStatus.IsDeleted,
                CreatedAt = meetingItemStatus.CreatedAt.ToString()
            };
        }

        public async Task<MeetingItemStatusEntity> DeleteMeetingItemStatusAsync(Guid meetingTypeGuid)
        {
            var meetingItemStatus = await _meetingItemStatusRepository.FindAsync(meetingTypeGuid);

            meetingItemStatus.IsDeleted = true;

            _meetingItemStatusRepository.Update(meetingItemStatus);
            await _meetingItemStatusRepository.SaveAsync();

            return new MeetingItemStatusEntity
            {
                Id = meetingItemStatus.Id,
                Name = meetingItemStatus.Name,
                IsDeleted = meetingItemStatus.IsDeleted,
                CreatedAt = meetingItemStatus.CreatedAt.ToString(),
                UpdatedAt = meetingItemStatus.UpdatedAt.ToString()
            };
        }

        public MeetingItemStatusEntity GetAllMeetingItemStatusesAsync()
        {
            var meetingItemStases = _meetingItemStatusRepository.Where(m => m.IsDeleted == false);

            return new MeetingItemStatusEntity
            {
                MeetingItemStatuses = meetingItemStases.Select(m => new MeetingItemStatusEntity
                {
                    Id = m.Id,
                    Name = m.Name
                })
            };
        }
    }
}
