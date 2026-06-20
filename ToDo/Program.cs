using System.Security.AccessControl;
using EspacioTarea;

/*
// CREAR LISTA VACÍA
List<string> frutas = new List<string>();

frutas.Add("Manzana");
frutas.Add("Banana");
frutas.Add("Naranja");

// INCIALIZAR LISTA con valores
List<int> numeros =
   new List<int>() { 10, 20, 30 };
*/

// funciones
List<Tarea> ListaVacia()
{
    return new List<Tarea>();
}

void AgregarTarea ( List<Tarea> lista, Tarea t)
{
    lista.Add(t);
}

void QuitarTarea ( List<Tarea> lista, Tarea t)
{
    lista.Remove(t);
}

void CargarTarea ( List<Tarea> lista, int id, string descrip, int durac)
{
    Tarea tareaNueva = new Tarea( id , descrip , durac );
    AgregarTarea(lista, tareaNueva);
}

void MostrarTarea (Tarea t)
{
    Console.WriteLine("\n--------------------");
    Console.WriteLine($"Tarea ID: [{t.TareaId}]");
    Console.WriteLine($"Descripción: \'{t.Descripcion}\'");
    Console.WriteLine($"Duración: {t.Duracion} días");
    Console.WriteLine("--------------------");
}

void MostrarLista (string tipoLista, List<Tarea> listaTareas)
{
    Console.WriteLine($"\nLISTA: Tareas {tipoLista}");
    foreach (Tarea t in listaTareas)
    {
        MostrarTarea(t);
    }
}

bool MoverTareaAListaRealizadas(List<Tarea> listaPendientes, List<Tarea> listaRealizadas, Tarea tareaAMover)
{
    //Tarea? tareaAMover = listaPendientes.FirstOrDefault(t => t.TareaId == id);
    QuitarTarea(listaPendientes, tareaAMover);
    AgregarTarea(listaRealizadas, tareaAMover);
    if ( listaRealizadas.Contains(tareaAMover) && !listaPendientes.Contains(tareaAMover) )
    { return true; }
    else
    { return false; }
}

bool BuscarTarea (List<Tarea> listaPendientes, string tBuscada)
{
    foreach (Tarea t in listaPendientes)
    {
        if (t.Descripcion == tBuscada)
        {
            MostrarTarea(t);
            Console.WriteLine("\nEstado: PENDIENTE");
            return true;
        }
    }
    return false;
}


//

/* 2. Cree aleatoriamente N tareas y guardelas en una lista dedicada a tareas 
pendientes (por ejemplo, List<Tarea> tareasPendientes).  */

int n = 5;
List<Tarea> tareasPendientes = ListaVacia();
Random rnd = new Random(); // defino un objeto 'rnd' tipo 'Random' para generar numeros aleatorios
// revisar el archivo Readme.md para más info de cómo usar esta función.

for (int i = 1; i <= n; i++)
{
    // Tarea tareaNueva = new Tarea( i , "tarea "+ i , rnd.Next(10,101) );
    // tareasPendientes.Add(tareaNueva);
    CargarTarea ( tareasPendientes, i , "tarea "+ i , rnd.Next(10,101) );
}

if (tareasPendientes.Count() == n)
{
    Console.WriteLine("\nLista de Tareas Pendientes cargada con éxito.");

    //MostrarLista ("PENDIENTES", tareasPendientes);
        
    //
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
    Console.ReadKey();
    //


    /* 3. Desarrolle una interfaz para mover las tareas pendientes a realizadas. 
    La lista de tareas realizadas (por ejemplo, List<Tarea> tareasRealizadas) 
    inicialmente estará vacía.  */

    List<Tarea> tareasRealizadas = ListaVacia();
    int seguir = 1;
    string? leer;
    int idLeido;
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n<<<< INTERFAZ DE USUARIO >>>>\n");
    Console.ResetColor();
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        MostrarLista ("PENDIENTES", tareasPendientes);
        Console.ResetColor();
        Console.WriteLine("\n¿Marcar tarea como REALIZADA? (SI: X | NO: 0): ");
        leer = Console.ReadLine();
        if (int.TryParse(leer, out seguir) && seguir != 0)
        {
            Console.WriteLine("\nIngresar el numero de la TAREA a mover:");
            leer = Console.ReadLine();
            if (int.TryParse(leer, out idLeido))
            {
                Tarea? tareaAMover = tareasPendientes.FirstOrDefault(t => t.TareaId == idLeido);
                if (tareaAMover != null)
                {
                    if ( MoverTareaAListaRealizadas(tareasPendientes, tareasRealizadas, tareaAMover) )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n>>> La tarea fue movida con éxito <<<");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        // tareasRealizadas.Sort();
                        MostrarLista ("REALIZADAS", tareasRealizadas);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nOCURRIÓ UN ERROR AL MOVER LA TAREA");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nLa tarea no se encuentra en 'Lista-Pendientes'.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEl valor ingresado no es válido\n");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    } while(seguir != 0);

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n---> FIN DEL PROGRAMA 1 <---\n");

    //
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
    Console.ReadKey();
    //

    /* 4. Desarrolle una función para buscar tareas pendientes por descripción y 
    mostrarla por consola.  */

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n>>> SEGUNDO PROGRAMA <<<\n");
    Console.ResetColor();
    Console.WriteLine("\nEscriba la descripcion de la tarea para buscar: ");
    string? tareaBuscada = Console.ReadLine();
    if ( !String.IsNullOrEmpty(tareaBuscada) )
    {
        bool encontrada = BuscarTarea(tareasPendientes, tareaBuscada);
        if ( !encontrada )
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nNo se ha encontrado la tarea '{tareaBuscada}' en PENDIENTES.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nEl valor ingresado no es válido\n");
        Console.ResetColor();
    }

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n---> FIN DEL PROGRAMA 2 <---\n");
    //
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
    Console.ReadKey();
    Console.ResetColor();
    //
    
    /* 5. Mostrar un listado de todas las tareas (pendientes y realizadas)  */

    MostrarLista("PENDIENTES", tareasPendientes);
    MostrarLista("REALIZADAS", tareasRealizadas);

    //
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
    Console.ReadKey();
    //

    /* 6. Diseña un menú principal que permita al usuario acceder a cada una de las funcionalidades descritas. 
    La interacción debe ser intuitiva (ej. "Presione 1 para...", "Ingrese el ID de la 
    tarea:", etc.).  */


}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nNo se pudo cargar correctamente la lista.");
    Console.ResetColor();
}
