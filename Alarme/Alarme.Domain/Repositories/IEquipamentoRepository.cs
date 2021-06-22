using Alarme.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Repositories
{
    public interface IEquipamentoRepository
    {
        void Adicionar(Equipamento equipamento);
        void Remover(Guid id);
        void Alterar(Equipamento equipamento);
        IEnumerable<Equipamento> Listar();
        Equipamento BuscarPorNome(string nome);
        Equipamento BuscarPorNumeroSerie(string numero);
        Equipamento BuscarPorId(Guid id);
    }
}
