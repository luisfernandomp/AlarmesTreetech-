using Alarme.Comum.CommandsQueries;
using Alarme.Comum.CommandsQueries.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Comum.Handlers
{
    public interface IHandleCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
