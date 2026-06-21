using EspacioOperaciones;
using EspacioCalculadora;

/*
EJERCICIO 2: Implementar el historial de cálculos realizados con la Calculadora que hizo en el Trabajo 
Práctico anterior. Para desarrollar esta funcionalidad, la clase Calculadora deberá incorporar 
una lista de objetos Operacion (List<Operacion>) donde se almacenará el historial de 
operaciones.
*/

// Se copio el codigo del Program.cs del tp anterior del proyecto "Calculadora"

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("--- INICIO ---\n");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Ingrese un numero: ");
Console.ResetColor();
double dato;
string? s = Console.ReadLine();
bool esOperable = double.TryParse(s, out dato);

if (esOperable)
{
    Calculadora numero = new Calculadora(dato);
    int seguir;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("¿Desea realizar una operación? SI(x)|NO(0) ");
    Console.ResetColor();
    s = Console.ReadLine();
    esOperable = int.TryParse(s, out seguir);
    bool estaLimpia = false;
    while (esOperable && seguir != 0)
    {
        if (estaLimpia)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingrese un NUEVO valor inicial:");
            Console.ResetColor();
            s = Console.ReadLine();
            if (double.TryParse(s, out dato))
            {
                numero = new Calculadora(dato);
                estaLimpia = false;
            }
        }
        double termino, num_anterior;
        num_anterior = numero.GetResultado;
        int operacion;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Selecciona una operación: ");
        Console.ResetColor();
        Console.WriteLine("(1): SUMA");
        Console.WriteLine("(2): RESTA");
        Console.WriteLine("(3): PRODUCTO");
        Console.WriteLine("(4): DIVISION");
        Console.WriteLine("(5): VER HISTORIAL");
        Console.WriteLine("(0): LIMPIAR");
        s = Console.ReadLine();
        esOperable = int.TryParse(s, out operacion);
        if (operacion >= 1 && operacion <=4)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingrese el segundo termino: ");
            Console.ResetColor();
            s = Console.ReadLine();
            esOperable = double.TryParse(s, out termino);
            if(esOperable)
            {
                switch (operacion)
                {
                    case 1:
                        numero.Sumar(termino);
                        Console.WriteLine($"{num_anterior} + {termino} = {numero.GetResultado}");
                        break;
                    case 2:
                        numero.Restar(termino);
                        Console.WriteLine($"{num_anterior} - {termino} = {numero.GetResultado}");
                        break;
                    case 3:
                        numero.Multiplicar(termino);
                        Console.WriteLine($"{num_anterior} * {termino} = {numero.GetResultado}");
                        break;
                    case 4:
                        if (termino != 0)
                        {
                            numero.Dividir(termino);
                            Console.WriteLine($"{num_anterior} / {termino} = {numero.GetResultado}");
                        }
                        else
                        {
                            Console.WriteLine("No es posible dividir en 0");
                        }
                        break;

                    default:
                        break;
                }
            }
        } else if (operacion == 5) {
            List<Operacion> historial = numero.Historial;
            Console.WriteLine("\n--- HISTORIAL ---");
            foreach (Operacion op in historial)
            {
                Console.WriteLine($"Op {historial.IndexOf(op)} => valor1 = {op.ResultadoAnterior} , valor2 = {op.NuevoValor} => Tipo: '{op.Op}'");
            }
            Console.WriteLine("-----------------");
            Console.WriteLine($"ULTIMO valor obtenido: {numero.GetResultado}");
            Console.WriteLine("-----------------\n");

        } else if (operacion == 0) {
            numero.Limpiar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------");
            Console.WriteLine("--> Calculadora REINICIADA <--");
            Console.WriteLine("------------------------------\n");
            Console.ResetColor();
            estaLimpia = true;

        } else {
            // Cambia el color del texto a rojo para indicar un error
            Console.ForegroundColor = ConsoleColor.Red;
            // Muestra el mensaje de error
            Console.WriteLine("Error: La opcion ingresada es inválida.");
            // Restaura el color original de la consola
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("¿Seguir operando? SI(x)|NO(0) ");
        Console.ResetColor();
        s = Console.ReadLine();
        esOperable = int.TryParse(s, out seguir);
    }

}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Error: el dato ingresado es inválido para operar.");
    Console.ResetColor();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n--- Fin del Programa ---");
Console.ResetColor();