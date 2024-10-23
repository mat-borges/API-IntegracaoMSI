using API_IntegracaoMSI.Entities.Cotacao;
using API_IntegracaoMSI.Repositories.Cotacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Services.Cotacao
{
    public class CotacaoService(CotacaoRepository cotacaoRepository)
    {
        private readonly CotacaoRepository _cotacaoRepository = cotacaoRepository;

        public async Task<MsiCotacao> ObterCotacaoValidaAsync(int id)
        {
            var cotacao = await _cotacaoRepository.ObterCotacaoPorIdAsync(id);

            return cotacao;
        }

        public async Task<List<MsiCotacao>> ObterCotacoesPaginadasAsync(int pageNumber, int pageSize)
        {
            return await _cotacaoRepository.ObterCotacoesPaginadasAsync(pageNumber, pageSize);
        }
    }
}
