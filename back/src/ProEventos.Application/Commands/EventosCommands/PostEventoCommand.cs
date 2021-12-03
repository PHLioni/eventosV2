using System;
using System.Collections.Generic;
using MediatR;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Commands.EventosCommands
{
    public class PostEventoCommand : IRequest<EventoDto>
    {
     
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}