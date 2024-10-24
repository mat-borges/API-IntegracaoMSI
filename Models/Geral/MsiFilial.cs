using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_IntegracaoMSI.Models.Cotacao;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Models.Geral;

[Table("WP_Filial")]
public partial class MsiFilial
{
    [Key]
    [Column("FilialID")]
    public int FilialID { get; set; }

    [Column("EmpresaID")]
    public int EmpresaID { get; set; }

    [Column("FilNome", TypeName = "nvarchar(255)")]
    public string FilNome { get; set; }

    [Column("FilEndereco", TypeName = "nvarchar(255)")]
    public string FilEndereco { get; set; }

    [Column("FilNo", TypeName = "nvarchar(50)")]
    public string FilNo { get; set; }

    [Column("FilBairro", TypeName = "nvarchar(100)")]
    public string FilBairro { get; set; }

    [Column("FilCEP", TypeName = "nvarchar(10)")]
    public string FilCEP { get; set; }

    [Column("FilCidade", TypeName = "nvarchar(100)")]
    public string FilCidade { get; set; }

    [Column("FilUF", TypeName = "nvarchar(2)")]
    public string FilUF { get; set; }

    [Column("FilDDD", TypeName = "nvarchar(5)")]
    public string FilDDD { get; set; }

    [Column("FilTelefone", TypeName = "nvarchar(15)")]
    public string FilTelefone { get; set; }

    [Column("FilFax", TypeName = "nvarchar(15)")]
    public string FilFax { get; set; }

    [Column("FilEmail", TypeName = "nvarchar(255)")]
    public string FilEmail { get; set; }

    public bool RegAtivo { get; set; }
    public bool Estipulante { get; set; }
    public bool ExibeMensagemApolice { get; set; }
    public bool ImobiliariaFiancaLocaticia { get; set; }
    public bool OrigemDaVenda { get; set; }

    [Column("FilialPaiID")]
    public int FilialPaiID { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string FilBanco { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string FilAgencia { get; set; }

    [Column(TypeName = "nvarchar(20)")]
    public string FilConta { get; set; }

    public DateTime? DataCadastro { get; set; }

    [Column(TypeName = "nvarchar(5)")]
    public string PrefixoTelefone { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string RotuloOrigemDaVenda { get; set; }

    [Column("FilTipoPIX")]
    public int? FilTipoPIX { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string FilChavePIX { get; set; }

    [ForeignKey("FilialOrigemId")]
    [InverseProperty("Filial")]
    public virtual ICollection<MsiCotacao> Cotacao { get; set; } = new List<MsiCotacao>();
}
