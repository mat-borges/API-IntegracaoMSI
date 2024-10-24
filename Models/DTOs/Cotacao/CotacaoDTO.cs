using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace API_IntegracaoMSI.Models.DTOs.Cotacao
{
    public class CotacaoDTO{
        public int CotacaoID { get; set; }
        public string Status { get; set; }
        public string Origem { get; set; }
        public string Observacoes{ get; set; }
        public bool Renovacao { get; set; }
        public string Filial { get; set; }
        public CotacaoSeguradoDTO CotacaoSegurado { get; set; }
    }

    public class CotacaoSeguradoDTO {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string TipoPessoa { get; set; }
        public string Cpfcnpj { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CEPResidencial { get; set; }
    }
}