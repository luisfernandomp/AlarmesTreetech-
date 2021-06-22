using Alarme.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Repositories
{
    public interface IAlarmeAutuadoRepository
    {
        void Adicionar(AlarmeAutuado alarmeAtuado);
        void Remover(Guid id);
        void Alterar(AlarmeAutuado alarme);
        IEnumerable<AlarmeAutuado> Listar();
        AlarmeAutuado BuscarPorId(Guid id);
    }
}
