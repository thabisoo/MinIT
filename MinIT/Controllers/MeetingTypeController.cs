using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinIT.ApplicationLogic.Entities.MeetingTypes;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Common.ViewModels.MeetingType;

namespace MinIT.Controllers
{
    public class MeetingTypeController : Controller
    {
        private readonly IMeetingTypeService _meetingTypService;

        public MeetingTypeController(IMeetingTypeService meetingTypService)
        {
            _meetingTypService = meetingTypService;
        }

        public IActionResult Index()
        {
            var meetingTypes = _meetingTypService.GetAllMeetingTypesAsync();

            var result = new MeetingTypeViewModel
            {
                MeetingTypes = meetingTypes.MeetingTypes.Select(m => new MeetingTypeViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeetingType(MeetingTypeViewModel meetingTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _meetingTypService.AddMeetingTypeAsync(new MeetingTypeEntity
                {
                    Name = meetingTypeViewModel.Name
                });
            }
            return Redirect("Index");
        }
    }
}