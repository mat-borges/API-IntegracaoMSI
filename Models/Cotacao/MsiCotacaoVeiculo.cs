using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Models.Cotacao;

[Table("MSI_CotacaoVeiculo")]
public partial class MsiCotacaoVeiculo
{
    [Key]
    [Column("CotacaoVeiculoID")]
    public int CotacaoVeiculoId { get; set; }

    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Column("MarcaID")]
    public int? MarcaId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Marca { get; set; }

    [Required]
    [StringLength(250)]
    [Unicode(false)]
    public string Modelo { get; set; }

    public int Ano { get; set; }

    public int AnoModelo { get; set; }

    public int NumeroDePortas { get; set; }

    [Column("ZeroKM")]
    public bool ZeroKm { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataRetiradaVeiculo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataNotaFiscal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ValorNotaFiscal { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Cor { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string Placa { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string Chassi { get; set; }

    [Column("CotacaoVeiculoTipoDeCombustivelID")]
    public int? CotacaoVeiculoTipoDeCombustivelId { get; set; }

    [Column("KitGNV")]
    public bool KitGnv { get; set; }

    [Column("ValorKitGNV", TypeName = "decimal(18, 2)")]
    public decimal ValorKitGnv { get; set; }

    public bool PossuiAlarme { get; set; }

    [Required]
    [StringLength(250)]
    [Unicode(false)]
    public string DescricaoAlarme { get; set; }

    [Column("CotacaoVeiculoFinanciamentoID")]
    public int? CotacaoVeiculoFinanciamentoId { get; set; }

    public bool? Blindado { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ValorBlindagem { get; set; }

    public bool? BlindagemDeFabrica { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string BlindagemNivel { get; set; }

    public bool? BlindagemContratar { get; set; }

    public int? BlindagemIdadeId { get; set; }

    public bool? Automatico { get; set; }

    public bool? Financiando { get; set; }

    [Required]
    [Column("CI")]
    [StringLength(50)]
    [Unicode(false)]
    public string Ci { get; set; }

    public bool VeiculoSelecionado { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Renavan { get; set; }

    public bool? Alienado { get; set; }

    [Column("CPFProprietario")]
    [StringLength(20)]
    [Unicode(false)]
    public string Cpfproprietario { get; set; }

    [Column("DispositivoAntiFurtoID")]
    public int? DispositivoAntiFurtoId { get; set; }

    public bool? ChassiRemarcado { get; set; }

    [Column("TipoDeUsoID")]
    public int? TipoDeUsoId { get; set; }

    [Column("TipoIsencaoFiscalID")]
    public int? TipoIsencaoFiscalId { get; set; }

    public int? CategoriaId { get; set; }

    public int? CorId { get; set; }

    public int? Quilometragem { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string UfPlaca { get; set; }

    [ForeignKey("CotacaoId")]
    [InverseProperty("CotacaoVeiculos")]
    public virtual MsiCotacao Cotacao { get; set; }
}
