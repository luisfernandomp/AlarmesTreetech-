using Alarme.Domain.Repositories;
using Alarme.Infra.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alarme.Infra.Repositories
{
    public class AlarmeRepository : IAlarmeRepository
    {
        private readonly AlarmeContext _context;

        public AlarmeRepository(AlarmeContext context)
        {
            _context = context;
        }

        public void Adicionar(Domain.Entidades.Alarme alarme)
        {
            _context.Alarmes.Add(alarme);
            _context.SaveChanges();
        }

        public void Alterar(Domain.Entidades.Alarme alarme)
        {
            _context.Entry(alarme).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public IEnumerable<Domain.Entidades.Alarme> Listar()
        {
            return _context.Alarmes
                    .AsNoTracking()
                    .Include(x => x.AlarmeEquipamentos)
                    .ToList();
        }

        public void Remover(Guid id)
        {
            Domain.Entidades.Alarme alarme = BuscarPorId(id);

            _context.Alarmes.Remove(alarme);

            _context.SaveChanges();
        }

        public Domain.Entidades.Alarme BuscarPorId(Guid id)
        {
            return _context.Alarmes
                 .AsNoTracking()
                 .FirstOrDefault(p => p.Id == id);
        }

        public Domain.Entidades.Alarme BuscarPelaDescricao(string descricao)
        {
            return _context.Alarmes
                 .AsNoTracking()
                 .FirstOrDefault(p => p.Descricao.ToLower() == descricao.ToLower());
        }


    }
}
