using API_IntegracaoMSI.Contexts.Cotacao;
using API_IntegracaoMSI.Models.Cotacao;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_IntegracaoMSI.Repositories.Cotacao
{
    public class CotacaoRepository(CotacaoContext context)
    {
        private readonly CotacaoContext _context = context;

        public async Task<MsiCotacao> ObterCotacaoPorIdAsync(int id)
        {
            return await _context.MsiCotacoes
                .Include(c => c.CotacaoStatus)
                .Include(c => c.CotacaoOrigem)
                .Include(c => c.Filial)
                .FirstOrDefaultAsync(c => c.CotacaoId == id);
        }

        public async Task<List<MsiCotacao>> ObterCotacoesPaginadasAsync(int pageNumber, int pageSize)
        {
            return await _context.MsiCotacoes
                .Include(c => c.CotacaoStatus)
                .Include(c => c.CotacaoOrigem)
                .Include(c => c.Filial)
                .OrderByDescending(c => c.DataCriacao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
