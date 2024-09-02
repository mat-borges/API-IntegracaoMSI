using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Entities
{
    public class Cliente
    {
        public int  ClienteID { get; set; }
        public string  CliNome { get; set; }
        public char CliTipoPessoa { get; set; }
        public char CliSexo { get; set; }
        public string CliTelefone { get; set; }

    }
}