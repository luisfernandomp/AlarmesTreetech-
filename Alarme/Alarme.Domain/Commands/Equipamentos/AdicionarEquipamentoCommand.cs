using Alarme.Comum.CommandsQueries.Command;
using Alarme.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Commands.Equipamentos
{
    public class AdicionarEquipamentoCommand : Notifiable, ICommand
    {
        public AdicionarEquipamentoCommand(string nome, string numeroSerie, EnTipoEquipamento tipo)
        {
            Nome = nome;
            NumeroSerie = numeroSerie;
            Tipo = tipo;
        }

        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public EnTipoEquipamento Tipo { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 5, "Nome", "Nome do equipamento deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "Nome", "Nome do equipamento deve conter até 40 caracteres")
                .IsNotNullOrEmpty(Nome, "Nome", "Informe o nome do equipamento")
                .HasLen(NumeroSerie, 7, "NumeroSerio", "Número de série do equipamento deve conter ter 7 caracteres")
            );
        }
    }
}
