using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Models.Cotacao;

[Table("MSI_CotacaoSeguradoRelacao")]
public partial class MsiCotacaoSeguradoRelacao
{
    [Key]
    [Column("CotacaoSeguradoRelacaoID")]
    public int CotacaoSeguradoRelacaoId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; }

    public bool? Ativo { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NomeMultiCalculo { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string TipoPessoa { get; set; }

    public int? CorretagemFacilId { get; set; }

    public bool? RelacaoComCondutor { get; set; }

    public bool? RelacaoComProprietario { get; set; }

    [InverseProperty("CotacaoSeguradoRelacao")]
    public virtual ICollection<MsiCotacaoSegurado> MsiCotacaoSegurados { get; set; } = new List<MsiCotacaoSegurado>();
}
