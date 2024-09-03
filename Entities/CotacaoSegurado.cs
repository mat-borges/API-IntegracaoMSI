using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Entities
{
    public class CotacaoSegurado
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int CotacaoID { get; set; }
        public char TipoPessoa { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneCelular { get; set; }
        public char Sexo { get; set; }
        public string CEP { get; set; }
    }
}