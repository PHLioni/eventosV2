using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProEventos.Application.Commands.EventosCommands;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Handlers.EventosHandlers
{
    public class PostEventoHandler : IRequestHandler<PostEventoCommand, EventoDto>
    {
        private readonly IChangePersistence _persistence;
        private readonly IMapper _mapper;
        private readonly IEventoPersistence _persistenceEv;

        public PostEventoHandler(IChangePersistence persistence, IMapper mapper, IEventoPersistence persistenceEv)
        {
            _persistence = persistence;
            _mapper = mapper;
            _persistenceEv = persistenceEv;
        }
        public async Task<EventoDto> Handle(PostEventoCommand request, CancellationToken cancellationToken)
        {            
            var evento = _mapper.Map<Evento>(request);
             _persistence.Add<Evento>(evento);

            if (await _persistence.SaveChangesAsync())
            {
                var retornoEvento = await _persistenceEv.GetAllEventoByIdAsync(evento.Id, false);

                return await Task.FromResult(_mapper.Map<EventoDto>(retornoEvento));
            }
            return null;
        }
    }
}