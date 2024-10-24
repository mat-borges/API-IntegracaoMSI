using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_IntegracaoMSI.Services.Cotacao;
using Microsoft.AspNetCore.Mvc;

namespace API_IntegracaoMSI.Controllers.Cotacao
{
	[ApiController]
	[Route("[controller]")]
	public class CotacaoController(CotacaoService cotacaoService) : ControllerBase
	{
		public readonly CotacaoService _cotacaoService = cotacaoService;

		// GET: api/Cotacao
		[HttpGet]
		public async Task<IActionResult> GetCotacoes(int pageNumber = 1, int pageSize = 10)
		{
			try{
				var cotacoes = await _cotacaoService.ObterCotacoesPaginadasAsync(pageNumber, pageSize);

				if (cotacoes == null)
				{
					return NotFound("Nenhuma cotacao encontrada.");
				}

				return Ok(cotacoes);
			} catch (Exception ex) {
				return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
			}
		}

		// GET: api/Cotacao/id
		[HttpGet("{id}")]
		public async Task<IActionResult> ObterPorID(int id) {
			var cotacao = await _cotacaoService.ObterCotacaoValidaAsync(id);
			if(cotacao == null){
				return NotFound($"Não foi encontrada nenhuma Cotação com esse ID ({id}).");
			}
			return Ok(cotacao);
		}
	}
}