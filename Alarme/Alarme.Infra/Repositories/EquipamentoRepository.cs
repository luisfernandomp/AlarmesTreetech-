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
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly AlarmeContext _context;

        public EquipamentoRepository(AlarmeContext context)
        {
            _context = context;
        }

        public void Adicionar(Equipamento equipamento)
        {
            _context.Equipamentos.Add(equipamento);
            _context.SaveChanges();
        }

        public void Alterar(Equipamento equipamento)
        {
            _context.Entry(equipamento).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public Equipamento BuscarPorNumeroSerie(string numero)
        {
            return _context.Equipamentos
                 .AsNoTracking()
                 .FirstOrDefault(e => e.NumeroSerie.ToLower() == numero.ToLower());
        }

        public IEnumerable<Equipamento> Listar()
        {
            return _context.Equipamentos
                    .AsNoTracking()
                    .Include(x => x.AlarmeEquipamentos)
                    .OrderBy(x => x.DataEntrada)
                    .ToList();
        }

        public void Remover(Guid id)
        {
            Equipamento equipamento = BuscarPorId(id);

            _context.Equipamentos.Remove(equipamento);

            _context.SaveChanges();
        }

        public Equipamento BuscarPorId(Guid id)
        {
            return _context.Equipamentos
                 .AsNoTracking()
                 .FirstOrDefault(p => p.Id == id);
        }

        public Equipamento BuscarPorNome(string nome)
        {
            return _context.Equipamentos
                 .AsNoTracking()
                 .FirstOrDefault(p => p.Nome.ToLower() == nome.ToLower());
        }
    }
}
