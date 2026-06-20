namespace EspacioTarea
{
    public class Tarea
    {
        private int tareaId;
        private string descripcion;
        private int duracion;

        public Tarea(int tareaId, string descripcion, int duracion)
        {
            this.tareaId = tareaId;
            this.descripcion = descripcion;
            if (duracion >= 10 && duracion <= 100)
            {
                this.duracion = duracion;
            }
            else
            {
                this.duracion = 10;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nSe esperaba una duración mínima de 10 hasta 100 días para el vencimiento de la tarea.\n");
                Console.ResetColor();
            }
        }

        public int TareaId 
        { 
            get => tareaId; 
            set => tareaId = value; 
        }
        public string Descripcion 
        { 
            get => descripcion; 
            set => descripcion = value; 
        }
        public int Duracion 
        { 
            get => duracion; 
            set => duracion = value; 
        }

    }

}