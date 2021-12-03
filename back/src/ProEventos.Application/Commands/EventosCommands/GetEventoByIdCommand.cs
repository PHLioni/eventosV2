using MediatR;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Commands.EventosCommands
{
    public class GetEventoByIdCommand : IRequest<EventoDto>
    {
        public int Id { get; set; }      
    }
}