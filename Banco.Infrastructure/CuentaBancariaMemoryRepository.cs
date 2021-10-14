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
        private readonly List<CuentaBancaria> _cuentasBancarias;

        public CuentaBancariaMemoryRepository()
        {
            _cuentasBancarias = new List<CuentaBancaria>()
            {
                new   CuentaAhorro("10101","CUENTA AHORRO 1"),
                new   CuentaCorriente("20202","CUENTA CORRIENTE 1",100000)
            };
        }
        public CuentaBancaria Find(string numero)
        {
            var cuentaBancaria=_cuentasBancarias.FirstOrDefault(t => t.Numero == numero);
            return cuentaBancaria;
        }

        public void Update(CuentaBancaria cuentaBancaria)
        {
            //COMO ESTAMOS EN MEMORIA LA ACTUIAIZCION ES AUTOMATICA
        }
    }
}
