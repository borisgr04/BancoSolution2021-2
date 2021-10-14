using Banco.Domain.Contracts;
using System;
using System.Linq;

namespace Banco.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BancoContext _bancoContext;
        public UnitOfWork(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            Inicializacion();
        }
        public ICuentaBancariaRepository CuentaBancariaRepository => new CuentaBancariaMemoryRepository(_bancoContext);

        public void BeginTransaction()
        {
            _bancoContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _bancoContext.SaveChanges();
            _bancoContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _bancoContext.Database.RollbackTransaction();
        }

        public void Inicializacion() 
        {
            if (_bancoContext.CuentasBancarias.Count() == 0) 
            {
                _bancoContext.CuentasBancarias.Add(new Domain.CuentaAhorro("10101", "Cuenta Ahorro 1"));
                _bancoContext.SaveChanges();
            }
            
        }
    }

    
}
