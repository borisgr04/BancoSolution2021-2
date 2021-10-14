using Banco.Domain;
using Banco.Domain.Contracts;
using Banco.Domain.CuentasBancarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Infrastructure
{
    public class CuentaBancariaMemoryRepository : ICuentaBancariaRepository
    {
        private readonly BancoContext _bancoContext;
        public CuentaBancariaMemoryRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public CuentaBancaria Find(string numero)
        {
            var cuentaBancaria= _bancoContext.CuentasBancarias.FirstOrDefault(t => t.Numero == numero);
            return cuentaBancaria;
        }

        public void Update(CuentaBancaria cuentaBancaria)
        {
            _bancoContext.CuentasBancarias.Update(cuentaBancaria as CuentaAhorro);
        }
    }
}
