using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Entities.Cotacao;

[Table("MSI_CotacaoSegurado")]
public partial class MsiCotacaoSegurado
{
    [Key]
    [Column("CotacaoSeguradoID")]
    public int CotacaoSeguradoId { get; set; }

    [Column("CotacaoID")]
    public int CotacaoId { get; set; }

    [Column("CotacaoSeguradoRelacaoID")]
    public int? CotacaoSeguradoRelacaoId { get; set; }

    [Required]
    [StringLength(250)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Required]
    [StringLength(1)]
    [Unicode(false)]
    public string TipoPessoa { get; set; }

    [Required]
    [Column("CPFCNPJ")]
    [StringLength(30)]
    [Unicode(false)]
    public string Cpfcnpj { get; set; }

    public DateOnly? DataNascimento { get; set; }

    [Required]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TelefonePrincipal { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TelefoneCelular { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TelefoneResidencial { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TelefoneComercial { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Fax { get; set; }

    public bool? SeguradoPoprietarioDoVeiculo { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string NomeProprietarioVeiculo { get; set; }

    [Column("CPFProprietarioVeiculo")]
    [StringLength(30)]
    [Unicode(false)]
    public string CpfproprietarioVeiculo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataNascimentoProprietarioVeiculo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataPrimeiraHabilitacaoProprietarioVeiculo { get; set; }

    [Column("EstadoCivilIDProprietarioVeiculo")]
    public int? EstadoCivilIdproprietarioVeiculo { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string SexoProprietarioVeiculo { get; set; }

    [Column("ProfissaoID")]
    public int? ProfissaoId { get; set; }

    [Column("RamoAtividadeID")]
    public int? RamoAtividadeId { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Sexo { get; set; }

    [Column("EstadoCivilID")]
    public int? EstadoCivilId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataPrimeiraHabilitacao { get; set; }

    [Column("CEPResidencial")]
    [StringLength(9)]
    [Unicode(false)]
    public string Cepresidencial { get; set; }

    [ForeignKey("CotacaoId")]
    [InverseProperty("MsiCotacaoSegurados")]
    public virtual MsiCotacao Cotacao { get; set; }

    [ForeignKey("CotacaoSeguradoRelacaoId")]
    [InverseProperty("MsiCotacaoSegurados")]
    public virtual MsiCotacaoSeguradoRelacao CotacaoSeguradoRelacao { get; set; }
}
