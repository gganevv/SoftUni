using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly HomiesDbContext data;

        public EventController(HomiesDbContext homiesDbContext)
        {
            data = homiesDbContext;
        }

        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .Select(e => new AllEventViewModel()
                {
                    Name = e.Name,
                    Id = e.Id,
                    Organiser = e.Organiser.UserName,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                }).ToArrayAsync();

            return View(events);
        }

        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            var events = await data.EventParticipants
                .Where(ep => ep.HelperId == GetUserId())
                .Select(e => new AllEventViewModel()
                {
                    Name = e.Event.Name,
                    Id = e.Event.Id,
                    Organiser = e.Event.Organiser.UserName,
                    Start = e.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Event.Type.Name
                }).ToArrayAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var types = await data.Types
                .Select(t => new Data.Models.Type()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArrayAsync();

            var model = new EventViewModel()
            {
                Types = types
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = GetUserId();

            var eventToAdd = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId
            };

            await data.Events.AddAsync(eventToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetUserId();
            var types = await data.Types
                .Select(t => new Data.Models.Type()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArrayAsync();
            var oldEvent = await data.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (oldEvent == null)
            {
                RedirectToAction("All", "Event");
            }

            if (userId != oldEvent.OrganiserId)
            {
                RedirectToAction("All", "Event");
            }

            var model = new EventViewModel()
            {
                Name = oldEvent.Name,
                Description = oldEvent.Description,
                StartStr = oldEvent.Start.ToString("yyyy-MM-dd H:mm"),
                EndStr = oldEvent.End.ToString("yyyy-MM-dd H:mm"),
                TypeId = oldEvent.TypeId,
                Types = types
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventViewModel model)
        {
            var userId = GetUserId();
            
            var oldEvent = await data.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (oldEvent == null)
            {
                RedirectToAction("All", "Event");
            }

            if (userId != oldEvent.OrganiserId)
            {
                RedirectToAction("All", "Event");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            oldEvent.Name = model.Name;
            oldEvent.Description = model.Description;
            oldEvent.Start = model.Start;
            oldEvent.End = model.End;
            oldEvent.TypeId = model.TypeId;

            await data.SaveChangesAsync();
            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int id)
        {
            var userId = GetUserId();
            IdentityUser orgranizer = data.Users.FirstOrDefault(u => u.Id == userId);
            var eventToJoin = new EventParticipant()
            {
                HelperId = userId,
                EventId = id
            };
            if (!data.EventParticipants.Any(e => e.EventId == id && e.HelperId == userId))
            {
                data.EventParticipants.Add(eventToJoin);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var userId = GetUserId();
            IdentityUser orgranizer = data.Users.FirstOrDefault(u => u.Id == userId);
            var eventToJoin = new EventParticipant()
            {
                HelperId = userId,
                EventId = id
            };
            if (data.EventParticipants.Any(e => e.EventId == id && e.HelperId == userId))
            {
                data.EventParticipants.Remove(eventToJoin);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("All", "Event");
        }
    }
}
