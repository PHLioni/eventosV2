using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;


namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
            
        }
          

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento(){
                EventoId = 1,
                Tema = "Pedro",
                Local = "Angular",
                Lote = "1",
                QtdPessoas = 250,
                DataEvento = "hoje"
            };
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento[]> GetById(int id){

        }
    }
}
