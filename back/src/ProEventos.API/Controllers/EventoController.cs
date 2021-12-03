using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Commands;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService, IMediator mediator)
        {
            _eventoService = eventoService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var query = new EventoCommand();
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }

            /*
           try
           {
               var eventos = await _eventoService.GetAllEventosAsync(true);
               if (eventos == null) return NotFound("Nenhum evento encontrado");
               return Ok(eventos);
           }
           catch (Exception ex)
           {
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
           }
            */
        }
    }
}
