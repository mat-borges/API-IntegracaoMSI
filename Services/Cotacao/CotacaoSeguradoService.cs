using API_IntegracaoMSI.Contexts.Cotacao;
using API_IntegracaoMSI.Entities.Cotacao;
using API_IntegracaoMSI.Repositories.Cotacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

 namespace API_IntegracaoMSI.Services.Cotacao
{
    public class CotacaoSeguradoService(CotacaoSeguradoRepository cotacaoSeguradoRepository)
    {
        private readonly CotacaoSeguradoRepository _cotacaoSeguradoRepository = cotacaoSeguradoRepository;

        public async Task<MsiCotacaoSegurado> ObterSeguradoPorCotacaoIdAsync(int cotacaoId)
        {
            return await _cotacaoSeguradoRepository.ObterSeguradoPorCotacaoIdAsync(cotacaoId);
        }
    }
}