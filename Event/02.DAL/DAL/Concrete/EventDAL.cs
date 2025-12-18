using Core.Concrete;
using DAL.Abstract;
using DAL.Database;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EventDAL : BaseRepository<Event, ApplicationDbContext>, IEventDAL
    {
        public List<Event> GetAllWithAttendees()
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from Event in context.Events
                             select new Event
                             {
                                 Id = Event.Id,
                                 Name = Event.Name,
                                 Type = Event.Type,
                                 Description = Event.Description,
                                 Deleted = Event.Deleted,
                                 Attendees = (from patient in context.Attendees
                                             where patient.EventId == Event.Id
                                             select patient).ToList()
                             };

                return result.ToList();
            }
        }

        public Event GetWithAttendees(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from Event in context.Events
                             where Event.Id == id
                             select new Event
                             {
                                 Id = Event.Id,
                                 Name = Event.Name,
                                 Type = Event.Type,
                                 Description = Event.Description,
                                 Deleted = Event.Deleted,
                                 Attendees = (from patient in context.Attendees
                                             where patient.EventId == Event.Id
                                             select patient).ToList()
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
