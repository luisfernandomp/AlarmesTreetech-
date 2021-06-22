using Alarme.Comum.CommandsQueries.Command;
using Alarme.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Commands.Alarmes
{
    public class AdicionarAlameCommand : Notifiable, ICommand
    {
        public AdicionarAlameCommand(string descricao, EnClassificacaoAlarme classificacao)
        {
            Descricao = descricao;
            Classificacao = classificacao;
        }

        public string Descricao { get; set; }
        public EnClassificacaoAlarme Classificacao { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Descricao, 5, "Descricao", "Descrição deve conter pelo menos 5 caracteres")
                .HasMaxLen(Descricao, 40, "Descricao", "Descrição do alarme deve conter até 40 caracteres")
                );
        }
    }
}
