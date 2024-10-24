using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Models.Cotacao;

[Table("MSI_CotacaoSeguro")]
public partial class MsiCotacaoSeguro
{
    [Key]
    [Column("CotacaoSeguroID")]
    public int CotacaoSeguroId { get; set; }

    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TipoSeguro { get; set; }

    [Column("CompanhiaSeguroID")]
    public int? CompanhiaSeguroId { get; set; }

    public int? BonusAtual { get; set; }

    public DateOnly? Vencimento { get; set; }

    public bool? HouveSinistro { get; set; }

    public int? QuantosSinistros { get; set; }

    [Column("CotacaoSeguroTipoSinistroID")]
    public int? CotacaoSeguroTipoSinistroId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Estado { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Cidade { get; set; }

    [Column("CotacaoSeguroTipoDeResidenciaID")]
    public int CotacaoSeguroTipoDeResidenciaId { get; set; }

    public bool PortaoAutomatico { get; set; }

    [Column("FrotaID")]
    public int? FrotaId { get; set; }

    [Column("CotacaoTipoMultiplosVeiculosID")]
    public int? CotacaoTipoMultiplosVeiculosId { get; set; }

    public int? CotacaoTipoMultiplosVeiculosQtdDiasSelecao { get; set; }

    [ForeignKey("CotacaoId")]
    [InverseProperty("CotacaoSeguros")]
    public virtual MsiCotacao Cotacao { get; set; }
}
