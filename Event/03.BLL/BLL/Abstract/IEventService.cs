using Core.Result.Abstract;
using Entities.DTO.EventDTO;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IEventService
    {
        IResult Add(EventAddDTO eventAddDTO);

        IResult Update(EventUpdateDTO eventUpdateDTO);
        IResult Delete(int id);

        IDataResult<List<EventListDTO>> GetAll();
        IDataResult<EventListDTO> Get(int id);
    }
}
