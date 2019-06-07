using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.ApplicationLogic.Services;
using MinIT.Common.ViewModels.Meeting;
using MinIT.Common.ViewModels.MeetingType;

namespace MinIT.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public IActionResult Index()
        {
            var meetings = _meetingService.GetAllMeetingsAsync();

            var meetingVM = new MeetingViewModel
            {
                MeetingTypes = meetings.MeetingTypes.Select(mt => new MeetingTypeViewModel { Id = mt.Id, Name = mt.Name }),
                Meetings = meetings.Meetings.Select(a => new MeetingViewModel
                {
                    Id = a.Id,
                    Number = a.Number,
                    DateTime = a.DateTime,
                    Type = a.MeetingType.Name 
                })
            };

            return View(meetingVM);
        }

        [HttpPost]
        [Route("Meeting/CreateMeeting")]
        public async Task<IActionResult> CreateMeeting(MeetingViewModel meetingViewModel)
        {
            var meeting = await _meetingService.CreateMeetingAsync(new CreateMeetingEntity
            {
                MeetingTypeId = meetingViewModel.MeetingType.Id,
                DateTime = meetingViewModel.DateTime,
                CarriedOverItemIds = meetingViewModel.CarriedOverItemIds
            });

            return Redirect("Index");
        }
    }
}