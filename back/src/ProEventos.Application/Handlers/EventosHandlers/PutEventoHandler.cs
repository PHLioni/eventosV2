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
    public class PutEventoHandler : IRequestHandler<PutEventoCommand, EventoDto>
    {
        private readonly IChangePersistence _persistence;
        private readonly IMapper _mapper;
        private readonly IEventoPersistence _persistenceEv;

        public PutEventoHandler(IChangePersistence persistence, IMapper mapper, IEventoPersistence persistenceEv)
        {
            _persistence = persistence;
            _mapper = mapper;
            _persistenceEv = persistenceEv;
        }

        public async Task<EventoDto> Handle(PutEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = await _persistenceEv.GetAllEventoByIdAsync(request.Id, false);

            if (evento == null) return null;

            request.Id = evento.Id;

            _mapper.Map(request, evento);

            _persistence.Update<Evento>(evento);

            if (await _persistence.SaveChangesAsync())
            {
                var eventoRetorno = await _persistenceEv.GetAllEventoByIdAsync(evento.Id, false);

                return await Task.FromResult(_mapper.Map<EventoDto>(eventoRetorno));
            }
            return null;
        }
    }
}