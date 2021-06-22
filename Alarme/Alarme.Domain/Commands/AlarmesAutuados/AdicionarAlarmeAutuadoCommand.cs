using Alarme.Comum.CommandsQueries.Command;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Commands.AlarmesAutuados
{
    public class AdicionarAlarmeAutuadoCommand : Notifiable, ICommand
    {
        public AdicionarAlarmeAutuadoCommand(DateTime dataSaida, bool status, Guid idAlarme)
        {
            DataSaida = dataSaida;
            Status = status;
            IdAlarme = idAlarme;
        }

        public DateTime DataSaida { get; set; }
        public bool Status { get; set; }
        public Guid IdAlarme { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdAlarme, Guid.Empty, "IdAlarme", "Informe o Id do alarme")
            );
        }
    }
}
