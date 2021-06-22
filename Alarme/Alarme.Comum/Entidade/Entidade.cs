using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alarme.Comum.Entidade
{
    public class Entidade : Notifiable, IEquatable<Entidade>
    {
        public Entidade()
        {
            Id = new Guid();
            DataEntrada = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataEntrada { get; set; }

        public bool Equals([AllowNull] Entidade other)
        {
            return Id == other.Id;
        }
    }
}
