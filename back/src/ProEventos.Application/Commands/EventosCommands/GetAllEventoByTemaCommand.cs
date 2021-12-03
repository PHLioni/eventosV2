using MediatR;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Commands.EventosCommands
{
    public class GetAllEventoByTemaCommand : IRequest<EventoDto[]> 
    {
        public string Tema { get; set; }
    }
}