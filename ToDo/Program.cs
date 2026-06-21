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

void CargarTarea ( List<Tarea> lista, int id, string descrip, int durac)
{
    Tarea tareaNueva = new Tarea( id , descrip , durac );
    lista.Add(tareaNueva);
}


/* 2. Cree aleatoriamente N tareas y guardelas en una lista dedicada a tareas 
pendientes (por ejemplo, List<Tarea> tareasPendientes).  */

void CargarListaPendientes (List<Tarea> listaPendientes, int n)
{
    Random rnd = new Random(); // defino un objeto 'rnd' tipo 'Random' para generar numeros aleatorios
    // revisar el archivo Readme.md para más info de cómo usar esta función.

    for (int i = 1; i <= n; i++)
    {
        CargarTarea ( listaPendientes, i , "tarea "+ i , rnd.Next(10,101) );
    }
}

void MostrarLista (string tipoLista, List<Tarea> listaTareas)
{
    Console.WriteLine($"\nLISTA: Tareas {tipoLista}");
    foreach (Tarea t in listaTareas)
    {
        t.MostrarTarea();
    }
}

bool MoverTareaAListaRealizadas(List<Tarea> listaPendientes, List<Tarea> listaRealizadas, Tarea tareaAMover)
{
    listaPendientes.Remove(tareaAMover);
    listaRealizadas.Add(tareaAMover);
    if ( listaRealizadas.Contains(tareaAMover) && !listaPendientes.Contains(tareaAMover) )
    { return true; }
    else
    { return false; }
}

Tarea? BuscarTarea (List<Tarea> listaPendientes, string tBuscada)
{
    foreach (Tarea t in listaPendientes)
    {
        if (t.Descripcion == tBuscada)
        {
            return t;
        }
    }
    return null;
}


/* 3. Desarrolle una interfaz para mover las tareas pendientes a realizadas. 
    La lista de tareas realizadas (por ejemplo, List<Tarea> tareasRealizadas) 
    inicialmente estará vacía.  */

void Operacion_MarcarTareaComoRealizada (List<Tarea> listaPendientes, List<Tarea> listaRealizadas, int idLeido)
{
    Tarea? tareaAMover = listaPendientes.FirstOrDefault(t => t.TareaId == idLeido);
    if (tareaAMover != null)
    {
        if ( MoverTareaAListaRealizadas(listaPendientes, listaRealizadas, tareaAMover) )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n>>> La tarea fue movida con éxito <<<");
            Console.ForegroundColor = ConsoleColor.Cyan;
            MostrarLista ("REALIZADAS", listaRealizadas);
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

/* 4. Desarrolle una función para buscar tareas pendientes por descripción y 
    mostrarla por consola.  */

void Operacion_BuscarTareaPorDescripcionEnPendientes (List<Tarea> listaPendientes, string tareaBuscada)
{
    Tarea? tareaEncontrada = BuscarTarea(listaPendientes, tareaBuscada);
    if ( tareaEncontrada != null )
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        tareaEncontrada.MostrarTarea();
        Console.WriteLine("\nEstado: PENDIENTE");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"\nNo se ha encontrado la tarea '{tareaBuscada}' en PENDIENTES.");
        Console.ResetColor();
    }
}


/* 5. Mostrar un listado de todas las tareas (pendientes y realizadas)  */

void Operacion_MostrarTodasLasTareas (List<Tarea> listaPendientes, List<Tarea> listaRealizadas)
{
    Console.WriteLine("\n********************");
    MostrarLista("PENDIENTES", listaPendientes);
    Console.WriteLine("********************");
    MostrarLista("REALIZADAS", listaRealizadas);
    Console.WriteLine("********************\n");
}



// CODIGO RPINCIPAL

int cantidadTareas = 5;
List<Tarea> tareasPendientes = ListaVacia();
CargarListaPendientes(tareasPendientes, cantidadTareas);

if (tareasPendientes.Count() == cantidadTareas)
{
    Console.WriteLine("\nLista de Tareas Pendientes cargada con éxito.");
    
    //
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
    Console.ReadKey();
    //

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n<<<< INICIO DEL PROGRAMA >>>>\n");
    Console.ResetColor();
    
    List<Tarea> tareasRealizadas = ListaVacia();

    string? leer;
    int operacion;
    do
    {
        //
        Console.WriteLine("\nMENU de Operaciones: [elegir una opcion]");
        Console.WriteLine("1. Marcar tarea como 'REALIZADA'");
        Console.WriteLine("2. Buscar tarea pendiente por descripción");
        Console.WriteLine("3. Mostrar listado de todas las tareas");
        Console.WriteLine("0. Finalizar");

        Console.WriteLine("\nOpcion: ");
        leer = Console.ReadLine();
        if (int.TryParse(leer, out operacion) && operacion != 0)
        {
            switch (operacion)
            {
                case 1:

                    int idLeido;
                    Console.WriteLine("\nIngresar el numero de la TAREA a mover:");
                    leer = Console.ReadLine();
                    if (int.TryParse(leer, out idLeido))
                    {
                        Operacion_MarcarTareaComoRealizada(tareasPendientes, tareasRealizadas, idLeido);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEl valor ingresado no es válido\n");
                        Console.ResetColor();
                    }
                    break;

                case 2:
                    
                    Console.WriteLine("\nEscriba la descripcion de la tarea para buscar: ");
                    string? tareaBuscada = Console.ReadLine();
                    if ( !String.IsNullOrEmpty(tareaBuscada) )
                    {
                        Operacion_BuscarTareaPorDescripcionEnPendientes(tareasPendientes, tareaBuscada);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEl valor ingresado no es válido\n");
                        Console.ResetColor();
                    }
                    break;

                case 3:

                    Operacion_MostrarTodasLasTareas(tareasPendientes, tareasRealizadas);
                    break;

                default:
                    break;
            }
            //
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR...");
            Console.ReadKey();
            Console.ResetColor();
        }

    } while(operacion != 0);

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n---> FIN DEL PROGRAMA 1 <---\n");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nNo se pudo cargar correctamente la lista.");
    Console.ResetColor();
}

//
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("\nPRESIONE UNA TECLA PARA CONTINUAR:");
Console.ReadKey();
Console.ResetColor();
//