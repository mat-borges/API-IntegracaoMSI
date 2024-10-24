using System.Threading.Tasks;
using API_IntegracaoMSI.Services.Cotacao;
using Microsoft.AspNetCore.Mvc;

namespace API_IntegracaoMSI.Controllers.Cotacao
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoSeguradoController(CotacaoSeguradoService cotacaoSeguradoService) : ControllerBase
    {
        private readonly CotacaoSeguradoService _cotacaoSeguradoService = cotacaoSeguradoService;

        // Método privado para buscar cotação e segurado, eliminando repetição
        private async Task<IActionResult> BuscarSeguradoPorCotacaoIDAsync(int cotacaoId)
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

        [HttpGet("{cotacaoId}")]
        public async Task<IActionResult> GetCotacaoSeguradoByCotacaoID(int cotacaoId){
            var segurado = await BuscarSeguradoPorCotacaoIDAsync(cotacaoId);
            if (segurado is OkObjectResult okObject){
                return Ok(okObject.Value);
            }

            return NotFound("Segurado não encontrado");
        }


        // Retorna o nome do segurado baseado no ID da Cotação
        [HttpGet("nome/{cotacaoId}")]
        public async Task<IActionResult> GetNomeSeguradoByCotacaoID(int cotacaoId)
        {
            var resultado = await BuscarSeguradoPorCotacaoIDAsync(cotacaoId);
            if (resultado is OkObjectResult okResult)
            {
                var cotacaoSegurado = okResult.Value as dynamic; // Usamos o valor do OkObjectResult

                return Ok(cotacaoSegurado?.PrimeiroNome + " " + cotacaoSegurado?.Sobrenome);
            }
            return NotFound("Segurado não encontrado");
        }

        [HttpGet("primeironome/{cotacaoId}")]
        public async Task<IActionResult> GetPrimeiroNomeSeguradoByCotacaoID(int cotacaoId)
        {
            var nomeResult = await GetNomeSeguradoByCotacaoID(cotacaoId);
            if (nomeResult is OkObjectResult okNomeResult)
            {
                var nomeCompleto = okNomeResult.Value as string;
                var primeiroNome = nomeCompleto?.Split(" ")[0];
                return Ok(primeiroNome);
            }

            return NotFound("Segurado não encontrado.");
        }

        [HttpGet("sobrenome/{cotacaoId}")]
        public async Task<IActionResult> GetSobrenomeSeguradoByCotacaoID(int cotacaoId)
        {
            var nomeResult = await GetNomeSeguradoByCotacaoID(cotacaoId);
            if (nomeResult is OkObjectResult okNomeResult)
            {
                var nomeCompleto = okNomeResult.Value as string;
                var nomePartes = nomeCompleto?.Split(" ");
                if (nomePartes != null && nomePartes.Length > 1){
                    var sobrenome = String.Join(" ", nomePartes.Skip(1));
                    return Ok(sobrenome);
                }
                return Ok("");
            }

            return NotFound("Segurado não encontrado.");
        }

        // Retorna o CPF/CNPJ do segurado baseado no ID da Cotação
        [HttpGet("cpfcnpj/{cotacaoId}")]
        public async Task<IActionResult> GetCpfCnpjByCotacaoID(int cotacaoId)
        {
            var resultado = await BuscarSeguradoPorCotacaoIDAsync(cotacaoId);
            if (resultado is OkObjectResult okResult)
            {
                var cotacaoSegurado = okResult.Value as dynamic;
                return Ok(cotacaoSegurado.Cpfcnpj);
            }
            return resultado;
        }

        // Retorna o CPF/CNPJ do segurado baseado no ID da Cotação
        [HttpGet("genero/{cotacaoId}")]
        public async Task<IActionResult> GetGeneroByCotacaoID(int cotacaoId)
        {
            var resultado = await BuscarSeguradoPorCotacaoIDAsync(cotacaoId);
            if (resultado is OkObjectResult okResult)
            {
                var cotacaoSegurado = okResult.Value as dynamic;
                return Ok(cotacaoSegurado.Sexo);
            }
            return resultado;
        }
    }
}
