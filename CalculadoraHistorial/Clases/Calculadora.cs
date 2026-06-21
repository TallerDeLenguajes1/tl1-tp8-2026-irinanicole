namespace EspacioCalculadora
{
    public class Calculadora {
        
        private double dato;

        public Calculadora(double dato)
        {
            this.dato = dato;
        }
        public void Sumar(double termino)
        {
            dato = dato + termino;
        }
        public void Restar(double termino)
        {
            dato = dato - termino;
        }
        public void Multiplicar(double termino)
        {
            dato = dato * termino;
        }
        public void Dividir(double termino)
        {
            dato = dato / termino;
        }
        public void Limpiar()
        {
            dato = 0;
        }

        public double GetResultado()
        {
            return dato;
        }



    }


}