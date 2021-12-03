using MediatR;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Commands
{
    public class EventoCommand : IRequest<EventoDto[]>
    {
        
    }
}