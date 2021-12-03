using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Commands.EventosCommands;

using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EventoController(IMediator mediator)
        {
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
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] GetEventoByIdCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response == null) return (NotFound("Evento não encontrado!"));
                return Ok(response);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }
        }

        [HttpGet("getByTema")]
        public async Task<IActionResult> GetByTema([FromQuery] GetAllEventoByTemaCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response == null) return (NotFound("Evento não encontrado!"));
                return Ok(response);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostEventoCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar evento. Erro {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutEventoCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response == null) return (NotFound("Evento não encontrado!"));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar editar evento. Erro {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteEventoCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response == null) return (NotFound("Evento não encontrado!"));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar evento. Erro {ex.Message}");
            }
        }
    }
}
