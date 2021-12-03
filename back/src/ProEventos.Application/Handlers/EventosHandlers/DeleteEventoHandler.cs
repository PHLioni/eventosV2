using System;
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
    public class DeleteEventoHandler : IRequestHandler<DeleteEventoCommand, EventoDto>
    {

        private readonly IChangePersistence _persistence;
        private readonly IMapper _mapper;
        private readonly IEventoPersistence _persistenceEv;
        public DeleteEventoHandler(IChangePersistence persistence, IMapper mapper, IEventoPersistence persistenceEv)
        {
            _persistence = persistence;
            _mapper = mapper;
            _persistenceEv = persistenceEv;
        }
        public async Task<EventoDto> Handle(DeleteEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = await _persistenceEv.GetAllEventoByIdAsync(request.Id, false);
            if(evento == null) return null;

            _mapper.Map(request, evento);

            _persistence.Delete<Evento>(evento);

            if(await _persistence.SaveChangesAsync()){
                return null;
            }
            return null;
        }
    }
}