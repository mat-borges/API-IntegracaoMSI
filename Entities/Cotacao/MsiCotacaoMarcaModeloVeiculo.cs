using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities.Cotacao;

[Table("MSI_CotacaoMarcaModeloVeiculos")]
public partial class MsiCotacaoMarcaModeloVeiculo
{
    [Key]
    [Column("CotacaoMarcaModeloVeiculosID")]
    public int CotacaoMarcaModeloVeiculosId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Marca { get; set; }

    [Required]
    [StringLength(300)]
    [Unicode(false)]
    public string Modelo { get; set; }

    [Column("MultiCalculoID")]
    public int? MultiCalculoId { get; set; }

    [Column("MultiCalculoFIPE")]
    [StringLength(20)]
    [Unicode(false)]
    public string MultiCalculoFipe { get; set; }
}
