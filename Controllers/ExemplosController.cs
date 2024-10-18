using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_IntegracaoMSI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExemplosController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                HoraSegundo = DateTime.Now.ToShortTimeString(),
                Hora = string.Format("{0:HH:mm:ss}", DateTime.Now)
            };
            return Ok(obj);
        }

        [HttpGet("Apresentar/nome")]
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá {nome}, seja bem vindo!";
            return Ok(new { mensagem });
        }
    }
}