using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Domain.CuentasBancarias;

namespace Banco.Domain.Contracts
{
    public interface ICuentaBancariaRepository
    {
        CuentaBancaria Find(string numero);
        void Update(CuentaBancaria cuentaBancaria);
    }
}
