using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProEventos.Application.Commands.EventosCommands;
using ProEventos.Application.Dtos;

using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Handlers.EventosHandlers
{
    public class GetEventoByIdHandler : IRequestHandler<GetEventoByIdCommand, EventoDto>
    {
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IMapper _mapper;

        public GetEventoByIdHandler(IEventoPersistence eventoPersistence, IMapper mapper)
        {
            _eventoPersistence = eventoPersistence;
            _mapper = mapper;
        }

        public async Task<EventoDto> Handle(GetEventoByIdCommand request, CancellationToken cancellationToken)
        {
        
            var evento = await _eventoPersistence.GetAllEventoByIdAsync(request.Id, false);
            

            return await Task.FromResult(_mapper.Map<EventoDto>(evento));
        }
    }
}