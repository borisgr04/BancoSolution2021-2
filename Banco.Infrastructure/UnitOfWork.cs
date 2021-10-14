using Banco.Domain.Contracts;
using System;

namespace Banco.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICuentaBancariaRepository CuentaBancariaRepository => new CuentaBancariaMemoryRepository();

        public void BeginTransaction()
        {
            //throw new NotImplementedException();
        }

        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public void Rollback()
        {
            //throw new NotImplementedException();
        }
    }
}
