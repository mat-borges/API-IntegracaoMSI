using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_IntegracaoMSI.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Context;

public class CotacaoContext : DbContext
{
    private readonly IConfiguration _configuration;
    public CotacaoContext(DbContextOptions<CotacaoContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<MsiCotacao> MsiCotacaos { get; set; }

    public virtual DbSet<MsiCotacaoEndereco> MsiCotacaoEnderecos { get; set; }

    public virtual DbSet<MsiCotacaoMarcaModeloVeiculo> MsiCotacaoMarcaModeloVeiculos { get; set; }

    public virtual DbSet<MsiCotacaoOcorrencium> MsiCotacaoOcorrencia { get; set; }

    public virtual DbSet<MsiCotacaoOrigem> MsiCotacaoOrigems { get; set; }

    public virtual DbSet<MsiCotacaoRelacaoComPrincipalCondutor> MsiCotacaoRelacaoComPrincipalCondutors { get; set; }

    public virtual DbSet<MsiCotacaoSegurado> MsiCotacaoSegurados { get; set; }

    public virtual DbSet<MsiCotacaoSeguradoRelacao> MsiCotacaoSeguradoRelacaos { get; set; }

    public virtual DbSet<MsiCotacaoSeguro> MsiCotacaoSeguros { get; set; }

    public virtual DbSet<MsiCotacaoStatus> MsiCotacaoStatuses { get; set; }

    public virtual DbSet<MsiCotacaoVeiculo> MsiCotacaoVeiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("ConexaoLocal");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<MsiCotacao>(entity =>
        {
            entity.HasIndex(e => e.CotacaoId, "_dta_index_MSI_Cotacao_45_1411640222__K1").HasFillFactor(80);

            entity.HasIndex(e => new { e.DataCriacao, e.CotacaoId, e.CotacaoSeguroId }, "_dta_index_MSI_Cotacao_45_1411640222__K10_K1_K17_2").HasFillFactor(80);

            entity.HasIndex(e => new { e.UsuarioDistribuidoId, e.DataCriacao, e.CotacaoId, e.CotacaoMotivoNaoFechadoId }, "_dta_index_MSI_Cotacao_45_1411640222__K2_K10_K1_K15").HasFillFactor(80);

            entity.HasIndex(e => e.CotacaoStatusId, "_dta_index_MSI_Cotacao_45_1411640222__K8").HasFillFactor(80);

            entity.HasIndex(e => new { e.DataCriacao, e.UsuarioDistribuidoId, e.CotacaoId, e.CotacaoStatusId }, "_dta_index_MSI_Cotacao_45_402204583__K10_K2_K1_K8_3_4_5_6_7_9_11_12_15_16_17_18_19_20_21_22_23_24").HasFillFactor(80);

            entity.HasIndex(e => new { e.ApoliceRenovadoId, e.CotacaoId }, "_dta_index_MSI_Cotacao_45_402204583__K22_K1_2_3_4_5_6_7_8_9_10_11_12_15_16_17_18_19_20_21_23_24").HasFillFactor(80);

            entity.HasIndex(e => e.UsuarioDistribuidoId, "_dta_index_MSI_Cotacao_45_402204583__K2_3").HasFillFactor(80);

            entity.Property(e => e.CotacaoSeguroId).HasDefaultValue(1);
            entity.Property(e => e.CotacaoStatusId).HasDefaultValue(1);
            entity.Property(e => e.FilialOrigemId).HasDefaultValue(15);
            entity.Property(e => e.MotivoSeguroNaoFechado).HasDefaultValue("");
            entity.Property(e => e.Observacoes).HasDefaultValue("");
            entity.Property(e => e.SiteOrigem).HasDefaultValue("");

            entity.HasOne(d => d.CotacaoOrigem).WithMany(p => p.MsiCotacaos).HasConstraintName("FK_MSI_Cotacao_MSI_Cotacao");

            entity.HasOne(d => d.CotacaoStatus).WithMany(p => p.MsiCotacaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MSI_Cotacao_MSI_CotacaoStatus");
        });

        modelBuilder.Entity<MsiCotacaoOcorrencium>(entity =>
        {
            entity.HasIndex(e => new { e.CotacaoId, e.OcorrenciaId }, "_dta_index_MSI_CotacaoOcorrencia_45_2117686692__K2_K1_3_5_6").HasFillFactor(80);

            entity.HasOne(d => d.Cotacao).WithMany(p => p.MsiCotacaoOcorrencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MSI_CotacaoOcorrencia_MSI_Cotacao");
        });

        modelBuilder.Entity<MsiCotacaoOrigem>(entity =>
        {
            entity.HasKey(e => e.CotacaoOrigemId).HasName("PK_MSI_CotacaoOritem");

            entity.Property(e => e.EnviaAvisoContato).HasDefaultValue(true);
            entity.Property(e => e.OrigemMaior).HasDefaultValue(true);
        });

        modelBuilder.Entity<MsiCotacaoSegurado>(entity =>
        {
            entity.HasKey(e => e.CotacaoSeguradoId).IsClustered(false);

            entity.HasIndex(e => new { e.CotacaoId, e.Cpfcnpj }, "_dta_index_MSI_CotacaoSegurado_45_482920892__K2_K6").HasFillFactor(80);

            entity.HasIndex(e => new { e.Nome, e.Cpfcnpj, e.CotacaoId }, "_dta_index_MSI_CotacaoSegurado_45_482920892__K4_K6_K2_9_10_11_12").HasFillFactor(80);

            entity.HasIndex(e => e.CotacaoId, "_dta_index_MSI_CotacaoSegurado_c_45_482920892__K2")
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.CpfproprietarioVeiculo).HasDefaultValue("");
            entity.Property(e => e.Fax).HasDefaultValue("");
            entity.Property(e => e.NomeProprietarioVeiculo).HasDefaultValue("");
            entity.Property(e => e.SeguradoPoprietarioDoVeiculo).HasDefaultValue(false);
            entity.Property(e => e.TelefoneCelular).HasDefaultValue("");
            entity.Property(e => e.TelefoneComercial).HasDefaultValue("");
            entity.Property(e => e.TelefonePrincipal).HasDefaultValue("");
            entity.Property(e => e.TelefoneResidencial).HasDefaultValue("");

            entity.HasOne(d => d.Cotacao).WithMany(p => p.MsiCotacaoSegurados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MSI_CotacaoSegurado_MSI_Cotacao");

            entity.HasOne(d => d.CotacaoSeguradoRelacao).WithMany(p => p.MsiCotacaoSegurados).HasConstraintName("FK_MSI_CotacaoSegurado_MSI_CotacaoSeguradoRelacao");
        });

        modelBuilder.Entity<MsiCotacaoSeguradoRelacao>(entity =>
        {
            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.NomeMultiCalculo).HasDefaultValue("");
        });

        modelBuilder.Entity<MsiCotacaoSeguro>(entity =>
        {
            entity.HasKey(e => e.CotacaoSeguroId).HasName("PK_MSI_CotacaoSeguro_1");

            entity.Property(e => e.QuantosSinistros).HasDefaultValue(0);

            entity.HasOne(d => d.Cotacao).WithMany(p => p.MsiCotacaoSeguros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MSI_CotacaoSeguro_MSI_Cotacao");
        });

        modelBuilder.Entity<MsiCotacaoStatus>(entity =>
        {
            entity.Property(e => e.CotacaoStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MsiCotacaoVeiculo>(entity =>
        {
            entity.HasIndex(e => e.CotacaoId, "_dta_index_MSI_CotacaoVeiculo_45_1314923856__K2_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25").HasFillFactor(80);

            entity.HasIndex(e => new { e.CotacaoId, e.VeiculoSelecionado }, "_dta_index_MSI_CotacaoVeiculo_45_1314923856__K2_K24_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_25").HasFillFactor(80);

            entity.HasIndex(e => e.Modelo, "_dta_index_MSI_CotacaoVeiculo_45_985210710__K5_2_12").HasFillFactor(80);

            entity.Property(e => e.Automatico).HasDefaultValue(false);
            entity.Property(e => e.Blindado).HasDefaultValue(false);
            entity.Property(e => e.Ci).HasDefaultValue("");
            entity.Property(e => e.DescricaoAlarme).HasDefaultValue("");
            entity.Property(e => e.Financiando).HasDefaultValue(false);
            entity.Property(e => e.Marca).HasDefaultValue("");
            entity.Property(e => e.ValorBlindagem).HasDefaultValue(0m);

            entity.HasOne(d => d.Cotacao).WithMany(p => p.MsiCotacaoVeiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MSI_CotacaoVeiculo_MSI_Cotacao");
        });
    }
}
