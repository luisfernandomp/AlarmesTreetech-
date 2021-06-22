using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Comum.CommandsQueries
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {

        }

        public GenericCommandResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
