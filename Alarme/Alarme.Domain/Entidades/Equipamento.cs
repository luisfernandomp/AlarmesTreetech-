using Alarme.Comum.Entidade;
using Alarme.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Entidades
{
    public class Equipamento : Entidade
    {
        public Equipamento(string nome, string numeroSerie, EnTipoEquipamento tipo)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 5, "Nome", "Nome do equipamento deve conter pelo menos 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "Nome do equipamento deve conter até 40 caracteres")
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome do equipamento")
                .HasLen(numeroSerie, 7, "NumeroSerio", "Número de série do equipamento deve conter ter 7 caracteres")
                .IsNotNullOrEmpty(tipo.ToString(), "Tipo", "Informe o tipo do equipamento")
            );

            if (Valid)
            {
                Nome = nome;
                NumeroSerie = numeroSerie;
                Tipo = tipo;
            }

        }

        public string Nome { get; private set; }
        public string NumeroSerie { get; private set; }
        public EnTipoEquipamento Tipo { get; private set; }
        public IList<AlarmeEquipamento> AlarmeEquipamentos { get; private set; }
    }
}
