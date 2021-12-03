using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IMapper _mapper;
        private readonly IChangePersistence _changePersistence;
        public EventoService(
            IChangePersistence changePersistence,
            IEventoPersistence eventoPersistence,
            IMapper mapper
        )
        {
            _changePersistence = changePersistence;
            _eventoPersistence = eventoPersistence;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _changePersistence.Add<Evento>(evento);
                
                if (await _changePersistence.SaveChangesAsync())
                {
                    var retorno = await _eventoPersistence.GetAllEventoByIdAsync(evento.Id, false);
                    //Não é obrigatório 

                    return _mapper.Map<EventoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) return null;
               
                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _changePersistence.Update<Evento>(evento);

                if (await _changePersistence.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersistence.GetAllEventoByIdAsync(evento.Id, false);
                    //Não é obrigatório 
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("O evento que deseja excluir não foi encontrado!");

                _changePersistence.Delete<Evento>(evento);
                return await _changePersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDto> GetAllEventoById(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}