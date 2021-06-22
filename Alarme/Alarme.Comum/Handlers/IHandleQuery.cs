using Alarme.Comum.CommandsQueries;
using Alarme.Comum.CommandsQueries.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Comum.Handlers
{
    public interface IHandleQuery<T> where T : IQuery
    {
        ICommandResult Handle(T query);
    }
}
