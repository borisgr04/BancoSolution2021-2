using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain
{
    public class CuentaCorriente
    {
        public string Numero { get; private set; }
        public string Nombre { get; private set; }
        public decimal Sobregiro { get; private set; }
        public decimal Saldo { get; private set; }

        private List<Movimiento> _movimientos;

        public IReadOnlyCollection<Movimiento> Movimientos => _movimientos.AsReadOnly();

        public CuentaCorriente(string numero, string nombre, decimal sobregiro)
        {
            Numero = numero;
            Nombre = nombre;
            Sobregiro = -sobregiro;
            _movimientos = new List<Movimiento>();
        }

        public string Consignar(decimal valorConsignacion, DateTime fecha)
        {
            if (!_movimientos.Any() && valorConsignacion < 100000)
            {
                return "El valor a consignar es incorrecto";
            }
            throw new NotImplementedException();
        }

        public string Retirar(decimal valorRetiro, DateTime fecha)
        {
            var nuevoSaldoTemporal = Saldo - valorRetiro - valorRetiro * 4 / 1000;
            if (nuevoSaldoTemporal > Sobregiro)
            {
                Saldo = nuevoSaldoTemporal;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }
    }

    public class CuentaCorrienteMovimiento
    {
        public CuentaCorrienteMovimiento(CuentaCorriente cuenta, DateTime fecha, string tipo, decimal valor)
        {
            Cuenta = cuenta;
            Fecha = fecha;
            Tipo = tipo;
            Valor = valor;
        }

        public CuentaCorriente Cuenta { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Tipo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
