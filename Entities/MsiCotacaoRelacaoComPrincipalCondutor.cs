using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities;

[Table("MSI_CotacaoRelacaoComPrincipalCondutor")]
public partial class MsiCotacaoRelacaoComPrincipalCondutor
{
    [Key]
    [Column("CotacaoRelacaoComPrincipalCondutorID")]
    public int CotacaoRelacaoComPrincipalCondutorId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; }
}
