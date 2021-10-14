using Banco.Domain;
using Banco.Domain.CuentasBancarias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Infrastructure
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options) { }

        public DbSet<CuentaAhorro> CuentasBancarias { get; set; }

    }

  
}
