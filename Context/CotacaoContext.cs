using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_IntegracaoMSI.Entities;

namespace API_IntegracaoMSI.Context
{
    public class CotacaoContext : DbContext
    {
        public CotacaoContext(DbContextOptions<CotacaoContext> options) : base(options)
        {

        }

        public DbSet<CotacaoSegurado> CotacaoSegurado { get; set; }
    }
}