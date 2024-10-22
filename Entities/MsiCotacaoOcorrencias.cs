using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities;

[Table("MSI_CotacaoOcorrencia")]
public partial class MsiCotacaoOcorrencium
{
    [Key]
    [Column("OcorrenciaID")]
    public int OcorrenciaId { get; set; }

    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    [Required]
    [Column(TypeName = "ntext")]
    public string Texto { get; set; }

    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    public bool Manual { get; set; }

    [ForeignKey("CotacaoId")]
    [InverseProperty("MsiCotacaoOcorrencia")]
    public virtual MsiCotacao Cotacao { get; set; }
}
