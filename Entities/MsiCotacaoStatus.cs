using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities;

[Table("MSI_CotacaoStatus")]
public partial class MsiCotacaoStatus
{
    [Key]
    [Column("CotacaoStatusID")]
    public int CotacaoStatusId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; }

    public int Ordem { get; set; }

    public bool ApenasConsultorContatoPodeAlterar { get; set; }

    public bool ApenasConsultorVendasPodeAlterar { get; set; }

    public bool PodeColocarManualmente { get; set; }

    public bool ExibeMotivo { get; set; }

    public bool EnviaEmailNaoConcretizado { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TempoLimiteEmMinutos { get; set; }

    public bool PodeFinalizarEdicao { get; set; }

    public bool ExpiraParaNaoConcretizado { get; set; }

    public bool PodeSerRenovado { get; set; }

    public bool PodeEspecificarDataQueExpirar { get; set; }

    public bool PodeColocarParaCotacaoCompania { get; set; }

    public bool Ativo { get; set; }

    public bool StatusFinal { get; set; }

    public bool ExibirNoFiltroBusca { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? LimiteMaximoParaRenovarDataExpiracaoEmMinutos { get; set; }

    [InverseProperty("CotacaoStatus")]
    public virtual ICollection<MsiCotacao> MsiCotacaos { get; set; } = new List<MsiCotacao>();
}
