using API_IntegracaoMSI.Contexts.Cotacao;
using API_IntegracaoMSI.Entities.Cotacao;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Repositories.Cotacao
{
    public class CotacaoRepository(CotacaoContext context)
    {
        private readonly CotacaoContext _context = context;

        public async Task<MsiCotacao> ObterCotacaoPorIdAsync(int id)
        {
            return await _context.MsiCotacoes.FindAsync(id);
        }

        public async Task<List<MsiCotacao>> ObterCotacoesPaginadasAsync(int pageNumber, int pageSize)
        {
            return await _context.MsiCotacoes
                .OrderByDescending(c => c.DataCriacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
