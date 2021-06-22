using Alarme.Comum.CommandsQueries;
using Alarme.Comum.Handlers;
using Alarme.Domain.Commands.Equipamentos;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Handler.Commands
{
    public class AdicionarEquipamentoHandler : Notifiable, IHandleCommand<AdicionarEquipamentoCommand>
    {
        public ICommandResult Handle(AdicionarEquipamentoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
