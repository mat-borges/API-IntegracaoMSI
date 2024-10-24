using API_IntegracaoMSI.Models.DTOs.Cotacao;
using API_IntegracaoMSI.Models.Cotacao;
using API_IntegracaoMSI.Repositories.Cotacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Humanizer;

namespace API_IntegracaoMSI.Services.Cotacao
{
    public class CotacaoService(CotacaoRepository cotacaoRepository, CotacaoSeguradoService cotacaoSeguradoService)
    {
        private readonly CotacaoRepository _cotacaoRepository = cotacaoRepository;
        private readonly CotacaoSeguradoService _cotacaoSeguradoService = cotacaoSeguradoService;

        public async Task<CotacaoDTO> ObterCotacaoValidaAsync(int id)
        {
            var cotacao = await _cotacaoRepository.ObterCotacaoPorIdAsync(id);
            var cotacaoSegurado = await _cotacaoSeguradoService.ObterSeguradoPorCotacaoIdAsync(id);

            if (cotacao == null) return null;

            var cotacaoDTO = new CotacaoDTO
            {
                CotacaoID = cotacao.CotacaoId,
                Status = cotacao.CotacaoStatus?.Nome.ToLower().Transform(To.TitleCase) ?? "Status não disponível",
                Origem = cotacao.CotacaoOrigem?.Nome.ToLower().Transform(To.TitleCase) ?? "Origem não disponível",
                Observacoes = cotacao.Observacoes,
                Renovacao = cotacao.Renovacao,
                Filial = cotacao.Filial?.FilNome.ToLower().Transform(To.TitleCase) ?? "Filial não disponível",
                CotacaoSegurado = cotacaoSegurado ?? null
            };

            return cotacaoDTO;
        }

        public async Task<List<MsiCotacao>> ObterCotacoesPaginadasAsync(int pageNumber, int pageSize)
        {
            return await _cotacaoRepository.ObterCotacoesPaginadasAsync(pageNumber, pageSize);
        }
    }
}
