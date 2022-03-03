using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistenza.Models
{
    public partial class missioniDbContext : DbContext
    {
        public missioniDbContext()
        {
        }

        public missioniDbContext(DbContextOptions<missioniDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnagraficaTipiMissione> AnagraficaTipiMissiones { get; set; }
        public virtual DbSet<CausaliMissione> CausaliMissiones { get; set; }
        public virtual DbSet<Missioni> Missionis { get; set; }
        public virtual DbSet<MissioniDipendenti> MissioniDipendentis { get; set; }
        public virtual DbSet<MissioniTransiti> MissioniTransitis { get; set; }
        public virtual DbSet<TipologieMissione> TipologieMissiones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=sipecdb;Username=postgres;Password=Pwd@gbos69");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<AnagraficaTipiMissione>(entity =>
            {
                entity.HasKey(e => e.IdAnagraficaTipiMissione)
                    .HasName("AnagraficaTipiMissione_PK");

                entity.ToTable("AnagraficaTipiMissione", "Missioni");

                entity.Property(e => e.IdAnagraficaTipiMissione)
                    .ValueGeneratedNever()
                    .HasColumnName("idAnagraficaTipiMissione");

                entity.Property(e => e.CapoTurno).HasColumnName("capoTurno");

                entity.Property(e => e.CodEvento).HasColumnName("codEvento");

                entity.Property(e => e.CodSedeMissione).HasColumnName("codSedeMissione");

                entity.Property(e => e.DescrizioneMissione)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("descrizioneMissione");

                entity.Property(e => e.DtFineValidita).HasColumnName("dtFineValidita");

                entity.Property(e => e.DtInizioValidita).HasColumnName("dtInizioValidita");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.IdTipologiaMissione).HasColumnName("idTipologiaMissione");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");
            });

            modelBuilder.Entity<CausaliMissione>(entity =>
            {
                entity.HasKey(e => e.IdCausaliMissione)
                    .HasName("CausaliMissione_PK");

                entity.ToTable("CausaliMissione", "Missioni");

                entity.Property(e => e.IdCausaliMissione)
                    .ValueGeneratedNever()
                    .HasColumnName("idCausaliMissione");

                entity.Property(e => e.DescCausaleMissione)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("descCausaleMissione");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.TipoMissione)
                    .HasMaxLength(1)
                    .HasColumnName("tipoMissione");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");
            });

            modelBuilder.Entity<Missioni>(entity =>
            {
                entity.HasKey(e => e.IdMissione)
                    .HasName("Missioni_PK");

                entity.ToTable("Missioni", "Missioni");

                entity.HasIndex(e => e.IdCausaliMissione, "MissioniDipendenti_UK");

                entity.Property(e => e.IdMissione)
                    .ValueGeneratedNever()
                    .HasColumnName("idMissione");

                entity.Property(e => e.CodEvento).HasColumnName("codEvento");

                entity.Property(e => e.CodSedeAmmDestinazione).HasColumnName("codSedeAmmDestinazione");

                entity.Property(e => e.CodSedeAmmPartenza).HasColumnName("codSedeAmmPartenza");

                entity.Property(e => e.CodSedeMissione).HasColumnName("codSedeMissione");

                entity.Property(e => e.DataInizioMissione).HasColumnName("dataInizioMissione");

                entity.Property(e => e.DataOraFineMissione).HasColumnName("dataOraFineMissione");

                entity.Property(e => e.DataOraInizioMissione).HasColumnName("dataOraInizioMissione");

                entity.Property(e => e.DtFineValidita).HasColumnName("dtFineValidita");

                entity.Property(e => e.DtInizioValidita).HasColumnName("dtInizioValidita");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.EstremiAutorizzazione)
                    .HasMaxLength(130)
                    .HasColumnName("estremiAutorizzazione");

                entity.Property(e => e.FlProv).HasColumnName("flProv");

                entity.Property(e => e.FlSedeVvf)
                    .IsRequired()
                    .HasColumnName("flSedeVvf")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IdAnagraficaTipiMissione).HasColumnName("idAnagraficaTipiMissione");

                entity.Property(e => e.IdCausaliMissione).HasColumnName("idCausaliMissione");

                entity.Property(e => e.IdTipologiaMissione)
                    .HasMaxLength(1)
                    .HasColumnName("idTipologiaMissione")
                    .HasDefaultValueSql("'M'::character varying");

                entity.Property(e => e.LocalitaDestinazione)
                    .HasMaxLength(200)
                    .HasColumnName("localitaDestinazione");

                entity.Property(e => e.LocalitaPartenza)
                    .HasMaxLength(200)
                    .HasColumnName("localitaPartenza");

                entity.Property(e => e.MezziTrasporto)
                    .HasMaxLength(50)
                    .HasColumnName("mezziTrasporto");

                entity.Property(e => e.MotivoMissione)
                    .HasMaxLength(150)
                    .HasColumnName("motivoMissione");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");

                //entity.HasOne(d => d.IdAnagraficaTipiMissioneNavigation)
                //    .WithMany(p => p.Missionis)
                //    .HasForeignKey(d => d.IdAnagraficaTipiMissione)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Missioni_FK2");

                entity.HasOne(d => d.IdCausaliMissioneNavigation)
                    .WithMany(p => p.Missionis)
                    .HasForeignKey(d => d.IdCausaliMissione)
                    .HasConstraintName("Missioni_FK1");

                entity.HasOne(d => d.IdTipologiaMissioneNavigation)
                    .WithMany(p => p.Missionis)
                    .HasForeignKey(d => d.IdTipologiaMissione)
                    .HasConstraintName("Missioni_FK3");
            });

            modelBuilder.Entity<MissioniDipendenti>(entity =>
            {
                entity.HasKey(e => new { e.IdMissione, e.IdDipendente })
                    .HasName("MissioniDipendenti_PK");

                entity.ToTable("MissioniDipendenti", "Missioni");

                entity.Property(e => e.IdMissione).HasColumnName("idMissione");

                entity.Property(e => e.IdDipendente).HasColumnName("idDipendente");

                entity.Property(e => e.CodFiscale)
                    .HasMaxLength(16)
                    .HasColumnName("codFiscale");

                entity.Property(e => e.DataOraArrivatoSede).HasColumnName("dataOraArrivatoSede");

                entity.Property(e => e.DataOraPartitoSede).HasColumnName("dataOraPartitoSede");

                entity.Property(e => e.DtFineValidita).HasColumnName("dtFineValidita");

                entity.Property(e => e.DtInizioValidita).HasColumnName("dtInizioValidita");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.FLavorato)
                    .HasColumnName("fLavorato")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IdMansione)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("idMansione")
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdMissioneNavigation)
                    .WithMany(p => p.MissioniDipendentis)
                    .HasForeignKey(d => d.IdMissione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MissioniDipendenti_FK");
            });

            modelBuilder.Entity<MissioniTransiti>(entity =>
            {
                entity.HasKey(e => new { e.IdMissione, e.IdDipendente, e.IdTransito })
                    .HasName("MissioniTransiti_PK");

                entity.ToTable("MissioniTransiti", "Missioni");

                entity.Property(e => e.IdMissione).HasColumnName("idMissione");

                entity.Property(e => e.IdDipendente).HasColumnName("idDipendente");

                entity.Property(e => e.IdTransito).HasColumnName("idTransito");

                entity.Property(e => e.DtFineValidita).HasColumnName("dtFineValidita");

                entity.Property(e => e.DtInizioValidita).HasColumnName("dtInizioValidita");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.MissioniTransitis)
                    .HasForeignKey(d => new { d.IdMissione, d.IdDipendente })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MissioniTransiti_FK");
            });

            modelBuilder.Entity<TipologieMissione>(entity =>
            {
                entity.HasKey(e => e.IdTipologiaMissione)
                    .HasName("TipologieMissione_PK");

                entity.ToTable("TipologieMissione", "Missioni");

                entity.Property(e => e.IdTipologiaMissione)
                    .HasMaxLength(1)
                    .HasColumnName("idTipologiaMissione");

                entity.Property(e => e.DescrTipMissione)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("descrTipMissione");

                entity.Property(e => e.DtIns).HasColumnName("dtIns");

                entity.Property(e => e.User)
                    .HasMaxLength(40)
                    .HasColumnName("user");

                entity.Property(e => e.VistiConTransiti)
                    .HasMaxLength(1)
                    .HasColumnName("vistiConTransiti")
                    .HasDefaultValueSql("'N'::character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
