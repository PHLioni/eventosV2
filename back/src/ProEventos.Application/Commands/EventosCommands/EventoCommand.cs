using MediatR;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Commands.EventosCommands
{
    public class EventoCommand : IRequest<EventoDto[]>
    {
        
    }
}