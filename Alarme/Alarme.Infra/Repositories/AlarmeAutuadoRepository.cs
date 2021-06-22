using Alarme.Domain.Entidades;
using Alarme.Domain.Repositories;
using Alarme.Infra.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alarme.Infra.Repositories
{
    public class AlarmeAutuadoRepository : IAlarmeAutuadoRepository
    {
        private readonly AlarmeContext _context;

        public AlarmeAutuadoRepository(AlarmeContext context)
        {
            _context = context;
        }

        public void Adicionar(AlarmeAutuado alarmeAutuado)
        {
            _context.AlarmesAutuados.Add(alarmeAutuado);
            _context.SaveChanges();
        }

        public void Alterar(AlarmeAutuado alarmeAutuado)
        {
            _context.Entry(alarmeAutuado).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public IEnumerable<AlarmeAutuado> Listar()
        {
            return _context.AlarmesAutuados
                    .AsNoTracking()
                    .Include(x => x.IdAlarme)
                    .OrderBy(x => x.DataEntrada)
                    .ToList();
        }

        public void Remover(Guid id)
        {
            AlarmeAutuado alarmeAutuado = BuscarPorId(id);

            _context.AlarmesAutuados.Remove(alarmeAutuado);

            _context.SaveChanges();
        }

        public AlarmeAutuado BuscarPorId(Guid id)
        {
            return _context.AlarmesAutuados
                 .AsNoTracking()
                 .FirstOrDefault(p => p.Id == id);
        }

    }
}
