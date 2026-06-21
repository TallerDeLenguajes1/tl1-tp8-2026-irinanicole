using EspacioOperaciones;

namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;
        private Operacion? operacion;
        private List<Operacion> historial;
        
        // funciones
        List<Operacion> ListaVacia()
        {
            return new List<Operacion>();
        }
        void RegistrarOperacionEnHistorial(double valor1, double valor2, TipoOperacion op)
        {
            operacion = new Operacion(valor1, valor2, op);
            historial.Add(operacion);
        }

        public Calculadora (double dato) // constructora
        {
            this.dato = dato;
            historial = ListaVacia();
        }

        // metodos para acceder al dato
        public double GetResultado
        {
            get => dato;
        }
        public List<Operacion> Historial 
        { 
            get => historial;
        }


        public void Sumar(double termino)
        {
            RegistrarOperacionEnHistorial(GetResultado, termino, TipoOperacion.Suma);
            dato = dato + termino;
        }
        public void Restar(double termino)
        {
            RegistrarOperacionEnHistorial(GetResultado, termino, TipoOperacion.Resta);
            dato = dato - termino;
        }
        public void Multiplicar(double termino)
        {
            RegistrarOperacionEnHistorial(GetResultado, termino, TipoOperacion.Multiplicacion);
            dato = dato * termino;
        }
        public void Dividir(double termino)
        {
            RegistrarOperacionEnHistorial(GetResultado, termino, TipoOperacion.Division);
            dato = dato / termino;
        }

        public void Limpiar()
        {
            RegistrarOperacionEnHistorial(GetResultado, 0, TipoOperacion.Limpiar);
            dato = 0;
        }
        

    }


}