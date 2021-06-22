using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Entidades
{
    public class AlarmeEquipamento : Notifiable
    {
        public Guid IdAlarme { get; set; }
        public Alarme Alarme { get; set; }

        public Guid IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }
    }
}
