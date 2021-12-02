using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IChangePersistence _changePersistence;
        public EventoService(IChangePersistence changePersistence, IEventoPersistence eventoPersistence)
        {
            _changePersistence = changePersistence;
            _eventoPersistence = eventoPersistence;

        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _changePersistence.Add<Evento>(model);
                if (await _changePersistence.SaveChangesAsync())
                {
                    //Não é obrigatório 
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _changePersistence.Update(model);
                if (await _changePersistence.SaveChangesAsync())
                {
                    //Não é obrigatório 
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false);
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


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> GetAllEventoById(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}