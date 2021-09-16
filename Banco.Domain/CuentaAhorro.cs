using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain
{
    public class CuentaAhorro
    {
        public string Numero { get; private set; }//encapsulamiento // guardar la integridad
        public string Nombre { get; private set; }
        public decimal Saldo { get; private set; }

        private List<Movimiento> _movimientos;

        public IReadOnlyCollection<Movimiento> Movimientos => _movimientos.AsReadOnly();

        public CuentaAhorro(string numero, string nombre)
        {
            Numero = numero;
            Nombre = nombre;
            _movimientos = new List<Movimiento>();
        }

        public string Consignar(decimal valorConsignacion, DateTime fecha)
        {
            if (valorConsignacion < 0)
            {
                return "El valor a consignar es incorrecto";
            }
            if (!_movimientos.Any() && valorConsignacion >= 50000)
            {
                _movimientos.Add(new Movimiento(cuentaAhorro: this, fecha: fecha, tipo: "CONSIGNACION", valor: valorConsignacion));
                Saldo += valorConsignacion;

                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }
    }

    public class Movimiento
    {
        public Movimiento(CuentaAhorro cuentaAhorro, DateTime fecha, string tipo, decimal valor)
        {
            CuentaAhorro = cuentaAhorro;
            Fecha = fecha;
            Tipo = tipo;
            Valor = valor;
        }

        public CuentaAhorro CuentaAhorro { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Tipo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
