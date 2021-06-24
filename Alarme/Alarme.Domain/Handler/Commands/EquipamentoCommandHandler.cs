using Alarme.Comum.CommandsQueries;
using Alarme.Comum.Enum;
using Alarme.Comum.Handlers;
using Alarme.Domain.Commands.Equipamentos;
using Alarme.Domain.Entidades;
using Alarme.Domain.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Domain.Handler.Commands
{
    public class AdicionarEquipamentoHandler : Notifiable, IHandleCommand<AdicionarEquipamentoCommand>
    {
        private readonly IEquipamentoRepository _repository;
        public AdicionarEquipamentoHandler(IEquipamentoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarEquipamentoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var equipamentoExiste = _repository.BuscarPorNumeroSerie(command.NumeroSerie);

            if (equipamentoExiste != null)
                return new GenericCommandResult(false, "Equipamento já cadastrado", null);

            Equipamento equipamento = new Equipamento(command.Nome, command.NumeroSerie, command.Tipo);

            if (equipamento.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", equipamento.Notifications);

            _repository.Adicionar(equipamento);

            return new GenericCommandResult(true, "Equipamento Adicionado", null);

        }

    }
}
