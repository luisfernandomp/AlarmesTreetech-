using Alarme.Comum.Entidade;
using Alarme.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alarme.Domain.Entidades
{
    public class Alarme : Entidade
    {
        private IList<AlarmeEquipamento> _alarmes;

        public Alarme(string descricao, EnClassificacaoAlarme classificacao)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(descricao, 5, "Descricao", "Descrição deve conter pelo menos 5 caracteres")
                .HasMaxLen(descricao, 40, "Descricao", "Descrição do alarme deve conter até 40 caracteres")
                );
            
            if (Valid)
            {
                Classificacao = classificacao;
                Descricao = descricao;
            }
        }

        public string Descricao { get; private set; }
        public EnClassificacaoAlarme Classificacao { get; private set; }
        public IReadOnlyCollection<AlarmeEquipamento> AlarmeEquipamentos { get { return _alarmes.ToArray(); } }
        public AlarmeAutuado AlarmesAutuados { get; private set; }
    }
}
