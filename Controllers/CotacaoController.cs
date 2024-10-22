using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_IntegracaoMSI.Context;
using API_IntegracaoMSI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_IntegracaoMSI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CotacaoController : ControllerBase
	{
		public readonly CotacaoContext _context;

		public CotacaoController(CotacaoContext context){
			_context = context;
		}

		// GET: api/Cotacao
		[HttpGet]
		public async Task<IActionResult> GetCotacoes(int pageNumber = 1, int pageSize = 10)
		{
			try{
				var query = _context.MsiCotacaos
            .OrderByDescending(c => c.DataCriacao);

				var cotacoes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

			if(cotacoes == null || cotacoes.Count == 0)
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
		public IActionResult ObterPorID(int id) {
			var cotacao = _context.MsiCotacaos.Find(id);
			if(cotacao == null){
				return NotFound("Não foi encontrada nenhuma Cotação com esse ID.");
			}
			return Ok(cotacao);
		}
	}
}