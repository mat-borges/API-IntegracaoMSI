using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities.Cotacao;

[Table("MSI_Cotacao")]
public partial class MsiCotacao
{
    [Key]
    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Column("UsuarioDistribuidoID")]
    public int? UsuarioDistribuidoId { get; set; }

    [Column("UsuarioDistribuidoID2")]
    public int? UsuarioDistribuidoId2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataDistribuicao { get; set; }

    public bool? DistribuicaoManual { get; set; }

    [Column("CotacaoPrioridadeID")]
    public int CotacaoPrioridadeId { get; set; }

    [Column("CotacaoOrigemID")]
    public int? CotacaoOrigemId { get; set; }

    [Column("CotacaoStatusID")]
    public int CotacaoStatusId { get; set; }

    [Column("CotacaoStatusID2")]
    public int? CotacaoStatusId2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataCriacao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataLimiteRetorno { get; set; }

    public bool ContatoApenasPorEmail { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Observacoes { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string MotivoSeguroNaoFechado { get; set; }

    [Column("CotacaoMotivoNaoFechadoID")]
    public int? CotacaoMotivoNaoFechadoId { get; set; }

    [Column("CotacaoSiteID")]
    public int? CotacaoSiteId { get; set; }

    [Column("CotacaoSeguroID")]
    public int CotacaoSeguroId { get; set; }

    public bool Renovada { get; set; }

    public bool Renovacao { get; set; }

    public bool ConfirmadoEndosso { get; set; }

    public bool AutorizadoRenovacaoStatus { get; set; }

    [Column("ApoliceRenovadoID")]
    public int? ApoliceRenovadoId { get; set; }

    [Column("CotacaoRenovadaID")]
    public int? CotacaoRenovadaId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataReagendamento { get; set; }

    [Column("UsuarioDistribuidoCalculoID")]
    public int? UsuarioDistribuidoCalculoId { get; set; }

    public bool? JaPossuiVeiculo { get; set; }

    public bool? JaAlugouImovel { get; set; }

    [Column("FilialOrigemID")]
    public int FilialOrigemId { get; set; }

    [Required]
    [Unicode(false)]
    public string SiteOrigem { get; set; }

    public int? MunicipioCodigo { get; set; }

    [Column("ClienteIndicacaoID")]
    public int? ClienteIndicacaoId { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal? Comissao { get; set; }

    public int? Versao { get; set; }

    public bool? VeiculoDeLeilao { get; set; }

    [Column("CotacaoAnteriorID")]
    public int? CotacaoAnteriorId { get; set; }

    [Column("CotacaoParceiroUsuarioID")]
    public int? CotacaoParceiroUsuarioId { get; set; }

    [Column("CotacaoParceiroFilialID")]
    public int? CotacaoParceiroFilialId { get; set; }

    [ForeignKey("CotacaoOrigemId")]
    [InverseProperty("MsiCotacoes")]
    public virtual MsiCotacaoOrigem CotacaoOrigem { get; set; }

    [ForeignKey("CotacaoStatusId")]
    [InverseProperty("MsiCotacoes")]
    public virtual MsiCotacaoStatus CotacaoStatus { get; set; }

    [InverseProperty("Cotacao")]
    public virtual ICollection<MsiCotacaoOcorrencium> MsiCotacaoOcorrencia { get; set; } = new List<MsiCotacaoOcorrencium>();

    [InverseProperty("Cotacao")]
    public virtual ICollection<MsiCotacaoSegurado> MsiCotacaoSegurados { get; set; } = new List<MsiCotacaoSegurado>();

    [InverseProperty("Cotacao")]
    public virtual ICollection<MsiCotacaoSeguro> MsiCotacaoSeguros { get; set; } = new List<MsiCotacaoSeguro>();

    [InverseProperty("Cotacao")]
    public virtual ICollection<MsiCotacaoVeiculo> MsiCotacaoVeiculos { get; set; } = new List<MsiCotacaoVeiculo>();
}
