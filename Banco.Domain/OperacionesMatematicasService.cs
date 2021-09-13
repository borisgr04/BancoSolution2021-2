using System;

namespace Banco.Domain
{
    //SUT => Sujeto bajo prueba 
    public class OperacionesMatematicasService
    {
        public OperacionesMatematicasService()
        {
        }

        public decimal Dividir(decimal dividendo, decimal divisor)
        {
            if (divisor == 0) 
            {
                throw new DivisionPorCeroException("El divisor no puede ser Cero.");
            }
            return dividendo / divisor;
        }
    }


    [Serializable]
    public class DivisionPorCeroException : Exception
    {
        public DivisionPorCeroException() { }
        public DivisionPorCeroException(string message) : base(message) { }
        public DivisionPorCeroException(string message, Exception inner) : base(message, inner) { }
        protected DivisionPorCeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
