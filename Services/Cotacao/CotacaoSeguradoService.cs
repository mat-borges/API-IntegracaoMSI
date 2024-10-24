using Humanizer;
using API_IntegracaoMSI.Models.DTOs.Cotacao;
using API_IntegracaoMSI.Repositories.Cotacao;
using System.Collections.Generic;
using System.Threading.Tasks;

 namespace API_IntegracaoMSI.Services.Cotacao
{
    public class CotacaoSeguradoService(CotacaoSeguradoRepository cotacaoSeguradoRepository)
    {
        private readonly CotacaoSeguradoRepository _cotacaoSeguradoRepository = cotacaoSeguradoRepository;

        public async Task<CotacaoSeguradoDTO> ObterSeguradoPorCotacaoIdAsync(int cotacaoId)
        {
            var cotacaoSegurado = await _cotacaoSeguradoRepository.ObterSeguradoPorCotacaoIdAsync(cotacaoId);

            if (cotacaoSegurado == null) return null;

            var nomeCompleto = cotacaoSegurado.Nome;
            var nomePartes = nomeCompleto?.Split(" ");
            var sobrenome = string.Join(" ", nomePartes.Skip(1));

            var cotacaoSeguradoDTO = new CotacaoSeguradoDTO {
                PrimeiroNome =  nomePartes[0].ToLower().Transform(To.TitleCase),
                Sobrenome =  sobrenome.ToLower().Transform(To.TitleCase),
                TipoPessoa = cotacaoSegurado.TipoPessoa,
                Cpfcnpj = cotacaoSegurado.Cpfcnpj,
                DataNascimento = cotacaoSegurado.DataNascimento,
                Email = cotacaoSegurado.Email.Transform(To.LowerCase),
                Telefone = cotacaoSegurado.TelefonePrincipal,
                Celular = cotacaoSegurado.TelefoneCelular,
                CEPResidencial = cotacaoSegurado.Cepresidencial
            };

            return cotacaoSeguradoDTO;
        }
    }
}