using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Repositories
{
    public interface IAlarmeRepository
    {
        void Adicionar(Entidades.Alarme alarme);
        void Remover(Guid id);
        void Alterar(Entidades.Alarme alarme);
        IEnumerable<Entidades.Alarme> Listar();
        Entidades.Alarme BuscarPelaDescricao(string descricao);
        Entidades.Alarme BuscarPorId(Guid id);
    }
}
