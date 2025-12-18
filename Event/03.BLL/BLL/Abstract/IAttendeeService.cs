using Core.Result.Abstract;
using Entities.DTO.AttendeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAttendeeService
    {
        IResult Add(AttendeeAddDTO attendeeAddDTO);

        IResult Update(AttendeeUpdateDTO attendeeUpdateDTO);
        IResult Delete(int id);

        IDataResult<List<AttendeeListDTO>> GetAll();
        IDataResult<AttendeeListDTO> Get(int id);
    }
}
