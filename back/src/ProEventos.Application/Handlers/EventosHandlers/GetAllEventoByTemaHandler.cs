using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProEventos.Application.Commands.EventosCommands;
using ProEventos.Application.Dtos;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Handlers.EventosHandlers
{
    public class GetAllEventoByTemaHandler : IRequestHandler<GetAllEventoByTemaCommand, EventoDto[]>
    {
        private readonly IEventoPersistence _persistence;
        private readonly IMapper _mapper;

        public GetAllEventoByTemaHandler(IEventoPersistence persistence, IMapper mapper)
        {
            _persistence = persistence;
            _mapper = mapper;
        }
        public async Task<EventoDto[]> Handle(GetAllEventoByTemaCommand request, CancellationToken cancellationToken)
        {
            var eventos = await _persistence.GetAllEventosByTemaAsync(request.Tema, false);

            return await Task.FromResult(_mapper.Map<EventoDto[]>(eventos));
        }
    }
}