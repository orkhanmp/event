using AutoMapper;
using Entities.DTO.AttendeeDTO;
using Entities.DTO.EventDTO;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class Map: Profile
    {
        public Map()
        {
            CreateMap<Event, EventAddDTO>().ReverseMap();
            CreateMap<Event, EventListDTO>().ReverseMap();
            CreateMap<Event, EventUpdateDTO>().ReverseMap();
            CreateMap<Attendee, AttendeeAddDTO>().ReverseMap();
            CreateMap<Attendee, AttendeeListDTO>().ReverseMap();
            CreateMap<Attendee, AttendeeUpdateDTO>().ReverseMap();
        }
    }
}
