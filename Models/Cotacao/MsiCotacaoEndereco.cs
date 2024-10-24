using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Models.Cotacao;

[Table("MSI_CotacaoEndereco")]
public partial class MsiCotacaoEndereco
{
    [Key]
    [Column("CotacaoEnderecoID")]
    public int CotacaoEnderecoId { get; set; }

    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Required]
    [Column("CEP")]
    [StringLength(10)]
    [Unicode(false)]
    public string Cep { get; set; }

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string Endereco { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string Numero { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Complemento { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string Bairro { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    [Unicode(false)]
    public string Estado { get; set; }

    [ForeignKey("CotacaoId")]
    [InverseProperty("CotacaoEndereco")]
    public MsiCotacao Cotacao { get; set; }
}
