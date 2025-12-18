using Core.Abstract;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IAttendeeDAL: IBaseRepository<Attendee>
    {
        List<Attendee> GetAllWithEvents();
        Attendee GetWithEvent(int id);
    }
}
