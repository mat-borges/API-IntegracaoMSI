using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities.Cotacao;

[Table("MSI_CotacaoOrigem")]
public partial class MsiCotacaoOrigem
{
    [Key]
    [Column("CotacaoOrigemID")]
    public int CotacaoOrigemId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; }

    public bool EnviaAvisoContato { get; set; }

    public bool OrigemMaior { get; set; }

    public bool OrigemSite { get; set; }

    public bool OrigemRenovacao { get; set; }

    public bool OrigemOutros { get; set; }

    public bool ExibirNoControleDeRetornos { get; set; }

    [InverseProperty("CotacaoOrigem")]
    public virtual ICollection<MsiCotacao> MsiCotacoes { get; set; } = new List<MsiCotacao>();
}
