using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Entities.MeetingTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Interfaces.Services
{
    public interface IMeetingService
    {
        Task<MeetingEntity> CreateMeetingAsync(CreateMeetingEntity meetingTypeEntity);

        MeetingEntity GetAllMeetingsAsync();
    }
}
