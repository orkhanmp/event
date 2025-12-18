using AutoMapper;
using BLL.Abstract;
using BLL.Extension;
using BLL.Validation;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DAL.Abstract;
using Entities.DTO.EventDTO;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class EventManager: IEventService
    {
        private readonly IEventDAL _eventDAL;
        private readonly IMapper  _mapper;

        public EventManager(IEventDAL eventDAL, IMapper mapper)
        {
            _eventDAL = eventDAL;
            _mapper = mapper;
            
        }

        public IResult Add(EventAddDTO eventAddDTO)
        {
            var mapperEvent = _mapper.Map<Event>(eventAddDTO);
            var validateValidator = new EventValidation();
            var validationResult = validateValidator.Validate(mapperEvent);

            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.FluentErrorString());

            _eventDAL.Add(mapperEvent);
            return new SuccessResult("Added Successfully");
        }

        public IResult Delete(int id)
        {
            var eventGet = _eventDAL.Get(x=> x.Id == id);

            if (eventGet is not null)
            {
                eventGet.Deleted=id;
                _eventDAL.Update(eventGet);                
                return new SuccessResult("Deleted Successfully");
            }

            return new ErrorResult("Event not found");
        }

        public IDataResult<EventListDTO> Get(int id)
        {
            var eventsById = _eventDAL.GetAll(x => x.Deleted == 0 && x.Id == id).FirstOrDefault();
            return new SuccessDataResult<EventListDTO>(_mapper.Map<EventListDTO>(eventsById));
        }

        public IDataResult<List<EventListDTO>> GetAll()
        {
            var events = _eventDAL.GetAll(x=>x.Deleted==0);
            return new SuccessDataResult<List<EventListDTO>>(_mapper.Map<List<EventListDTO>>(events));
        }

        public IResult Update(EventUpdateDTO eventUpdateDTO)
        {
            var eventMapper = _mapper.Map<Event>(eventUpdateDTO);
            var validateValidator = new EventValidation();
            var validationResults = validateValidator.Validate(eventMapper);
            
            if(!validationResults.IsValid) 
                return new ErrorResult(validationResults.Errors.FluentErrorString());

            _eventDAL.Update(eventMapper);
            return new SuccessResult("Updated Successfully");
        }
    }
}
