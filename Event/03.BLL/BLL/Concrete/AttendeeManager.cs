using AutoMapper;
using BLL.Abstract;
using BLL.Extension;
using BLL.Validation;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DAL.Abstract;
using Entities.DTO.AttendeeDTO;
using Entities.DTO.EventDTO;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class AttendeeManager: IAttendeeService
    {
        private readonly IAttendeeDAL _attendeeDAL;
        private readonly IMapper _mapper;

        public AttendeeManager(IAttendeeDAL attendeeDAL, IMapper mapper)
        {
            _attendeeDAL = attendeeDAL;
            _mapper = mapper;

        }

        public IResult Add(AttendeeAddDTO attendeeAddDTO)
        {
            var mapperAttendee = _mapper.Map<Attendee>(attendeeAddDTO);
            var validateValidator = new AttendeeValidation();
            var validationResult = validateValidator.Validate(mapperAttendee);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorString());

            _attendeeDAL.Add(mapperAttendee);
            return new SuccessResult("Added Successfully");
        }

        public IResult Delete(int id)
        {
            var attendeeGet = _attendeeDAL.Get(x => x.Id == id);

            if (attendeeGet != null)
            {
                attendeeGet.Deleted = id;

                _attendeeDAL.Update(attendeeGet);
                return new SuccessResult("Deleted Successfully");
            }

            return new ErrorResult("Attendee not found");
        }

        public IDataResult<AttendeeListDTO> Get(int id)
        {
            var attendeeById = _attendeeDAL.GetAll(x => x.Deleted == 0 && x.Id == id).FirstOrDefault();
            return new SuccessDataResult<AttendeeListDTO>(_mapper.Map<AttendeeListDTO>(attendeeById));
        }

        public IDataResult<List<AttendeeListDTO>> GetAll()
        {
            var attendees = _attendeeDAL.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<AttendeeListDTO>>(_mapper.Map<List<AttendeeListDTO>>(attendees));
        }

        public IResult Update(AttendeeUpdateDTO attendeeUpdateDTO)
        {
            var attendeeMapper = _mapper.Map<Attendee>(attendeeUpdateDTO);
            var validateValidator = new AttendeeValidation();
            var validationResults = validateValidator.Validate(attendeeMapper);

            if (!validationResults.IsValid)
                return new ErrorResult(validationResults.Errors.FluentErrorString());

            _attendeeDAL.Update(attendeeMapper);
            return new SuccessResult("Updated Successfully");
        }
    }
}
