using System.Threading.Tasks;
using API_IntegracaoMSI.Services.Cotacao;
using Microsoft.AspNetCore.Mvc;

namespace API_IntegracaoMSI.Controllers.Cotacao
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoSeguradoController(CotacaoService cotacaoService, CotacaoSeguradoService cotacaoSeguradoService) : ControllerBase
    {
        private readonly CotacaoService _cotacaoService = cotacaoService;
        private readonly CotacaoSeguradoService _cotacaoSeguradoService = cotacaoSeguradoService;

        // Método privado para buscar cotação e segurado, eliminando repetição
        private async Task<IActionResult> BuscarSeguradoPorCotacaoAsync(int cotacaoId)
        {
            try
            {
                var cotacaoSegurado = await _cotacaoSeguradoService.ObterSeguradoPorCotacaoIdAsync(cotacaoId);

                if (cotacaoSegurado == null)
                {
                    return NotFound("Não foi encontrado nenhum segurado relacionado a essa Cotação.");
                }

                return Ok(cotacaoSegurado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }


        // Retorna o nome do segurado baseado no ID da Cotação
        [HttpGet("nome/{cotacaoId}")]
        public async Task<IActionResult> GetNomeSeguradoByCotacaoID(int cotacaoId)
        {
            var resultado = await BuscarSeguradoPorCotacaoAsync(cotacaoId);
            if (resultado is OkObjectResult okResult)
            {
                var cotacaoSegurado = okResult.Value as dynamic; // Usamos o valor do OkObjectResult
                return Ok(cotacaoSegurado.Nome);
            }
            return resultado;
        }

        // Retorna o CPF/CNPJ do segurado baseado no ID da Cotação
        [HttpGet("cpfcnpj/{cotacaoId}")]
        public async Task<IActionResult> GetCpfCnpjByCotacaoID(int cotacaoId)
        {
            var resultado = await BuscarSeguradoPorCotacaoAsync(cotacaoId);
            if (resultado is OkObjectResult okResult)
            {
                var cotacaoSegurado = okResult.Value as dynamic;
                return Ok(cotacaoSegurado.Cpfcnpj);
            }
            return resultado;
        }
    }
}
