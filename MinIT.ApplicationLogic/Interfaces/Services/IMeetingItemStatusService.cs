using MinIT.ApplicationLogic.Entities.MeetingItemStatus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Interfaces.Services
{
    public interface IMeetingItemStatusService
    {
        Task<MeetingItemStatusEntity> AddMeetingItemStatusAsync(MeetingItemStatusEntity meetingTypeEntity);

        Task<MeetingItemStatusEntity> DeleteMeetingItemStatusAsync(Guid meetingTypeGuid);

        MeetingItemStatusEntity GetAllMeetingItemStatusesAsync();
    }
}
