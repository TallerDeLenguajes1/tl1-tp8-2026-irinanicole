namespace EspacioOperaciones
{
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar // Representa la acción de BORRAR el resultado actual (nuevoValor) o el historial (nuevoValor y resultadoAnterior)
    }
    public class Operacion
    {
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual;
        private double nuevoValor; // El valor con el que se opera sobre el 'resultadoAnterior'
        private TipoOperacion op; // El tipo de operación realizada


        // Propiedad pública para acceder al nuevo valor utilizado en la operación
        public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
        public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
        public TipoOperacion Op { get => op; set => op = value; }

        // Constructor
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion op)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.op = op;
        }

    } 
}
