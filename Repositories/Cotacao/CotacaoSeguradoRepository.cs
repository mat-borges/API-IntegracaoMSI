using API_IntegracaoMSI.Contexts.Cotacao;
using API_IntegracaoMSI.Models.Cotacao;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Repositories.Cotacao
{
    public class CotacaoSeguradoRepository(CotacaoContext context)
    {
        private readonly CotacaoContext _context = context;

        public async Task<MsiCotacaoSegurado> ObterSeguradoPorCotacaoIdAsync(int cotacaoId)
        {
            try{
                return await _context.MsiCotacaoSegurados.FirstOrDefaultAsync(s => s.CotacaoId == cotacaoId);
            } catch (Exception ex){
                throw new KeyNotFoundException($"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
