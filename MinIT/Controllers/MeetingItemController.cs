using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MinIT.ApplicationLogic.Entities.Items;
using MinIT.ApplicationLogic.Entities.Meetings;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Common.ViewModels.Item;
using MinIT.Common.ViewModels.Meeting;
using MinIT.Common.ViewModels.MeetingItemStatus;
using MinIT.Common.ViewModels.User;

namespace MinIT.Controllers
{
    public class MeetingItemController : Controller
    {
        private readonly IItemService _itemService;

        public MeetingItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index(Guid Id)
        {
            var meetingItems = _itemService.GetAllItemsForMeetingAsync(Id);

            var meetingItemViewModel = new ItemViewModel
            { 
                Meeting =  new MeetingViewModel {
                    Id = meetingItems.Meeting.Id,
                    Number = meetingItems.Meeting.Number,
                    DateTime = meetingItems.Meeting.DateTime,
                },
                Items = meetingItems.Items.Select(i => new ItemViewModel{
                    Id = i.Id,
                    Description = i.Description,
                    DueDate = i.DueDate,
                    Comment = i.Comment,
                    User = new UserViewModel
                    {
                        Id = i.User.Id,
                        FirstName = i.User.FirstName,
                        LastName = i.User.LastName
                    }
                }),
                Users = meetingItems.Users.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }),
                MeetingItemStatuses = meetingItems.MeetingItemStatuses.Select(v => new MeetingItemStatusViewModel
                {
                    Id = v.Id,
                    Name = v.Name
                })
            }; 

            return View(meetingItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeetingItem(ItemViewModel meetingItemViewViewModel)
        {
            var item = await _itemService.AddItemAsync(new ItemEntity
            {
                Description = meetingItemViewViewModel.Description,
                UserId = meetingItemViewViewModel.UserId,
                DueDate = meetingItemViewViewModel.DueDate,
                Meeting = new MeetingEntity
                {
                    Id = meetingItemViewViewModel.Meeting.Id
                }
            });

            return RedirectToAction("Index", new RouteValueDictionary( new { controller = "MeetingItem", action = "Index", Id = item.Meeting.Id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditMeetingItem(ItemViewModel meetingItemViewViewModel)
        {
            var result = await _itemService.EditMeetingItemAsync(new ItemEntity
            {
                Id = meetingItemViewViewModel.Id,
                Description = meetingItemViewViewModel.Description,
                UserId = meetingItemViewViewModel.UserId,
                DueDate = meetingItemViewViewModel.DueDate,
                Comment = meetingItemViewViewModel.Comment,
                Meeting = new MeetingEntity
                {
                    Id = meetingItemViewViewModel.Meeting.Id
                }
            });

            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "MeetingItem", action = "Index", Id = result.Meeting.Id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditMeetingItemStatus(ItemViewModel meetingItemViewViewModel)
        {
            var result = await _itemService.EditMeetingItemStatusAsync(new ItemEntity
            {
                Id = meetingItemViewViewModel.Id,
                ItemStatusId = meetingItemViewViewModel.ItemStatusId,
                Meeting = new MeetingEntity
                {
                    Id = meetingItemViewViewModel.Meeting.Id,
                }
            });

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetPreviousMeetingItems(Guid Id)
        {
            var previosItems = _itemService.GetPreviousMeetingItemsAsync(Id);

            var result = previosItems.Select(i => new ItemViewModel
            {
                Id = i.Id,
                Description = i.Description,
                User = new UserViewModel
                {
                    FirstName = i.User.FirstName,
                    LastName = i.User.LastName
                }
            });

            return Ok(result);
        }

        [HttpGet]
        [Route("MeetingItem/Index/MeetingItem/GetMeetingItem/{Id}")]
        public IActionResult GetMeetingItem(Guid Id)
        {
            var meetingItem = _itemService.GetMeetingItemAsync(Id);

            var result = new ItemViewModel
            {
                Id = meetingItem.Id,
                Description = meetingItem.Description,
                DueDate = meetingItem.DueDate,
                UserId = meetingItem.UserId,
                Comment = meetingItem.Comment,
                ItemStatusId = meetingItem.ItemStatusId,
                
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("MeetingItem/Index/MeetingItem/History/{id}")]
        public IActionResult History(Guid Id)
        {

            var result = _itemService.GetItemHistory(Id);

            return Ok(result);
        }
    }
}