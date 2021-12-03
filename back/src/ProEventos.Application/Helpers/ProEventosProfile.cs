using AutoMapper;
using ProEventos.Application.Commands.EventosCommands;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.API.Helpers
{
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Evento, PostEventoCommand>().ReverseMap();            
            CreateMap<Evento, PutEventoCommand>().ReverseMap();            
            CreateMap<Evento, DeleteEventoCommand>().ReverseMap();            
        }    

    }
}