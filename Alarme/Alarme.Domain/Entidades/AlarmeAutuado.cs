using Alarme.Comum.Entidade;
using Alarme.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Entidades
{
    public class AlarmeAutuado : Entidade
    {
        public AlarmeAutuado(DateTime dataSaida, bool status, Guid idAlarme)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(idAlarme, Guid.Empty, "IdAlarme", "Informe o Id do alarme")
                );

            if (Valid)
            {
                Status = status;
                DataSaida = dataSaida;
                IdAlarme = idAlarme;
            }
        }

        public DateTime DataSaida { get; private set; }
        public bool Status { get; private set; }
        public Guid IdAlarme { get; private set; }
        public virtual Alarme Alarme { get; private set; }

        public void AlterarStatus()
        {
            if (Status == true) Status = false;
            else Status = true;
        }
    }
}
