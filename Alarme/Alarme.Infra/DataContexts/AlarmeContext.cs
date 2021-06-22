using Alarme.Domain.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alarme.Infra.DataContexts
{
    public class AlarmeContext : DbContext
    {
        public AlarmeContext(DbContextOptions<AlarmeContext> options) :
            base(options)
        {

        }

        public DbSet<Domain.Entidades.Alarme> Alarmes { get; set; }
        public DbSet<AlarmeAutuado> AlarmesAutuados { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<AlarmeEquipamento> AlarmeEquipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
            modelBuilder.Entity<Equipamento>().Property(x => x.Id);
            modelBuilder.Entity<Equipamento>().Property(x => x.Nome).HasMaxLength(30);
            modelBuilder.Entity<Equipamento>().Property(x => x.Nome).HasColumnType("varchar(30)");
            modelBuilder.Entity<Equipamento>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<Equipamento>().Property(x => x.NumeroSerie).HasMaxLength(30);
            modelBuilder.Entity<Equipamento>().Property(x => x.NumeroSerie).HasColumnType("varchar(30)");
            modelBuilder.Entity<Equipamento>().Property(x => x.NumeroSerie).IsRequired();
            modelBuilder.Entity<Equipamento>().Property(x => x.Tipo).HasColumnType("int");
            modelBuilder.Entity<Equipamento>().Property(x => x.DataEntrada).HasColumnType("DateTime");
            modelBuilder.Entity<Equipamento>().Property(x => x.DataEntrada).HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Domain.Entidades.Alarme>().ToTable("Alarmes");
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.Id);
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.Descricao).HasMaxLength(40);
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.Descricao).HasColumnType("varchar(40)");
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.Descricao).IsRequired();
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.Classificacao).HasColumnType("int");
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(x => x.DataEntrada).HasColumnType("DateTime");
            modelBuilder.Entity<Domain.Entidades.Alarme>().Property(t => t.DataEntrada).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Domain.Entidades.Alarme>()
                .HasOne(a => a.AlarmesAutuados)
                .WithOne(ad => ad.Alarme)
                .HasForeignKey<AlarmeAutuado>(x => x.IdAlarme);

            modelBuilder.Entity<AlarmeAutuado>().ToTable("AlarmesAtuados");
            modelBuilder.Entity<AlarmeAutuado>().Property(x => x.Id);
            modelBuilder.Entity<AlarmeAutuado>().Property(x => x.DataEntrada).HasColumnType("DateTime");
            modelBuilder.Entity<AlarmeAutuado>().Property(t => t.DataEntrada).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<AlarmeAutuado>().Property(x => x.DataSaida).HasColumnType("DateTime");
            modelBuilder.Entity<AlarmeAutuado>().Property(x => x.Status).HasColumnType("bit");

            modelBuilder.Entity<AlarmeEquipamento>()
                .HasKey(ae => new { ae.IdAlarme, ae.IdEquipamento });

            modelBuilder.Entity<AlarmeEquipamento>()
                .HasOne(x => x.Alarme)
                .WithMany(y => y.AlarmeEquipamentos)
                .HasForeignKey(ae => ae.IdAlarme);

            modelBuilder.Entity<AlarmeEquipamento>()
                .HasOne(x => x.Equipamento)
                .WithMany(c => c.AlarmeEquipamentos)
                .HasForeignKey(ae => ae.IdEquipamento);

            base.OnModelCreating(modelBuilder);
        }
    }
}
