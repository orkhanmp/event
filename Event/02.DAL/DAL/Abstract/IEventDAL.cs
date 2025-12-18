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
    public interface IEventDAL: IBaseRepository<Event>
    {
        List<Event> GetAllWithAttendees();
        Event GetWithAttendees(int id);
    }
}
