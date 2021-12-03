using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProEventos.Application.Commands.EventosCommands;
using ProEventos.Application.Dtos;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Handlers.EventosHandlers
{
    public class EventoHandler : IRequestHandler<EventoCommand, EventoDto[]>
    {
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IMapper _mapper;

        public EventoHandler(IEventoPersistence eventoPersistence, IMapper mapper)
        {
            _eventoPersistence = eventoPersistence;
            _mapper = mapper;
        }
        public async Task<EventoDto[]> Handle(EventoCommand request, CancellationToken cancellationToken)
        {

            var eventos = await _eventoPersistence.GetAllEventosAsync(false);


            return await Task.FromResult(_mapper.Map<EventoDto[]>(eventos));

        }
    }
}