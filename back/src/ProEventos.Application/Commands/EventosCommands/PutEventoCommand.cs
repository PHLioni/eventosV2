using System;
using MediatR;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Commands.EventosCommands
{
    public class PutEventoCommand : IRequest<EventoDto>
    {
        
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}