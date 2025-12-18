using Core.Concrete;
using DAL.Abstract;
using DAL.Database;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AttendeeDAL : BaseRepository<Attendee, ApplicationDbContext>, IAttendeeDAL
    {
        public List<Attendee> GetAllWithEvents()
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from attendee in context.Attendees
                             join Event in context.Events
                             on attendee.EventId equals Event.Id
                             where attendee.Deleted == 0
                             select new Attendee
                             {
                                 Id = attendee.Id,
                                 Name = attendee.Name,
                                 Surname = attendee.Surname,
                                 Email = attendee.Email,
                                 Age = attendee.Age,                                 
                                 EventId = attendee.EventId,
                                 Event = Event
                             };

                return result.ToList();
            }
        }

        public Attendee GetWithEvent(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from attendee in context.Attendees
                             join Event in context.Events
                             on attendee.EventId equals Event.Id
                             where attendee.Id == id && attendee.Deleted == 0
                             select new Attendee
                             {
                                 
                                 Id = attendee.Id,
                                 Name = attendee.Name,
                                 Surname = attendee.Surname,
                                 Email = attendee.Email,
                                 Age = attendee.Age,
                                 EventId = attendee.EventId,
                                 Event = Event
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
