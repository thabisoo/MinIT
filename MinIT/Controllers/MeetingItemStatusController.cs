using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinIT.ApplicationLogic.Entities.MeetingItemStatus;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Common.ViewModels.MeetingItemStatus;

namespace MinIT.Controllers
{
    
    public class MeetingItemStatusController : Controller
    {
        private readonly IMeetingItemStatusService _meetingItemStatusService;

        public MeetingItemStatusController(IMeetingItemStatusService meetingItemStatusService)
        {
            _meetingItemStatusService = meetingItemStatusService;
        }

        public IActionResult Index()
        {
            var meetingItemStatuses = _meetingItemStatusService.GetAllMeetingItemStatusesAsync();

            var result = new MeetingItemStatusViewModel
            {
                MeetingItemStatuses = meetingItemStatuses.MeetingItemStatuses.Select(m => new MeetingItemStatusViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
            };
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeetingItemStatus(MeetingItemStatusViewModel meetingTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _meetingItemStatusService.AddMeetingItemStatusAsync(new MeetingItemStatusEntity
                { 
                    Name = meetingTypeViewModel.Name
                });
           
            }
            return Redirect("Index");
        }
    }
}