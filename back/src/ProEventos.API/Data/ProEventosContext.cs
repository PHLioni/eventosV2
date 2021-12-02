using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class ProEventosContext: DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){}
        public DbSet<Evento> Eventos { get; set; }
    }
}