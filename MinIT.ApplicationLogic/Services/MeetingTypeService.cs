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
    public class MeetingTypeService : IMeetingTypeService
    {
        private readonly IBaseRepository<MeetingType> _meetingTypeRepository;

        public MeetingTypeService(IBaseRepository<MeetingType> meetingTypeRepository)
        {
            _meetingTypeRepository = meetingTypeRepository;
        }

        public async Task<MeetingTypeEntity> AddMeetingTypeAsync(MeetingTypeEntity meetingTypeEntity)
        {
            var meetingType = new MeetingType
            {
                Name = meetingTypeEntity.Name,
                IsDeleted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };

            _meetingTypeRepository.Add(meetingType);
            await _meetingTypeRepository.SaveAsync();

            return new MeetingTypeEntity
            {
                Id = meetingType.Id,
                Name = meetingType.Name,
                IsDeleted = meetingType.IsDeleted,
                CreatedAt = meetingType.CreatedAt.ToString()
            };
        }

        public async Task<MeetingTypeEntity> DeleteMeetingTypeAsync(Guid meetingTypeGuid)
        {
            var meetingType = await _meetingTypeRepository.FindAsync(meetingTypeGuid);

            meetingType.IsDeleted = true;

            _meetingTypeRepository.Update(meetingType);
            await _meetingTypeRepository.SaveAsync();

            return new MeetingTypeEntity
            {
                Id = meetingType.Id,
                Name = meetingType.Name,
                IsDeleted = meetingType.IsDeleted,
                CreatedAt = meetingType.CreatedAt.ToString(),
                UpdatedAt = meetingType.UpdatedAt.ToString()
            };
        }

        public MeetingTypeEntity GetAllMeetingTypesAsync()
        {
            var meetingTypes = _meetingTypeRepository.Where(m => m.IsDeleted == false);

            return new MeetingTypeEntity
            {
               MeetingTypes = meetingTypes.Select(m => new MeetingTypeEntity
               {
                   Id = m.Id,
                   Name = m.Name
               })
            };
        }
    }
}
