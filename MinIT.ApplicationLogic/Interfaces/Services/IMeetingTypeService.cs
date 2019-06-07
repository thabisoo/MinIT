using MinIT.ApplicationLogic.Entities.MeetingTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Interfaces.Services
{
    public interface IMeetingTypeService
    {
        Task<MeetingTypeEntity> AddMeetingTypeAsync(MeetingTypeEntity meetingTypeEntity);

        Task<MeetingTypeEntity> DeleteMeetingTypeAsync(Guid meetingTypeGuid);

        MeetingTypeEntity GetAllMeetingTypesAsync();
    }
}
