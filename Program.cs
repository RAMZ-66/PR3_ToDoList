using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PR3_ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;

            string opcion = "0";

            CultureInfo culture = new CultureInfo("es-MX");

            string todayAsStr = today.ToString("d/M/yyyy");  

            ListaActividades listaPendientes = new ListaActividades();  

            ListaActividades registroCompletados = new ListaActividades();

            Console.WriteLine("-----------");
            Console.WriteLine("To Do List");
            Console.WriteLine("-----------");
            Console.WriteLine("");

            while(opcion != "9")
            {
                opcion = "0";
                Console.WriteLine("Porfavor selecciona una opción válida:");
                Console.WriteLine("");

                Console.WriteLine("1) Agregar una tarea por hacer");
                Console.WriteLine("");
                Console.WriteLine("2) Mostrar las tareas registradas");
                Console.WriteLine("");
                Console.WriteLine("3) Completar tarea");
                Console.WriteLine("");
                Console.WriteLine("4) Borrar tarea");
                Console.WriteLine("");
                Console.WriteLine("5) Guardar archivo");
                Console.WriteLine("");
                Console.WriteLine("9) Salir del programa");
                Console.WriteLine("");

                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("Introduce la tarea que deseas agregar:");
                    Console.WriteLine("");
                    string fecha = todayAsStr; 
                    string input = Console.ReadLine();
                    Console.WriteLine("");

                    Registro registro = new Registro (input, fecha, false); 

                    listaPendientes.Agregar(registro);
                }

                else if (opcion == "2")
                {
                    listaPendientes.MostrarTodo();
                }

                else if (opcion == "3")
                {
                    Console.WriteLine("Selecciona la tarea a completar:");
                    Console.WriteLine("");
                    listaPendientes.CompletarTarea();
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                // Opción 4, borrar una tarea de la lista de tareas por hacer, o de la lista de tareas completadas

                else if (opcion == "4")
                {
                    Console.WriteLine("Selecciona el tipo de tarea a borrar:");
                    Console.WriteLine("1) Tareas por completar");
                    Console.WriteLine("2) Tareas completadas");
                    
                    string opcionABorrar = Console.ReadLine();

                    if (opcionABorrar == "1")
                    {
                        Console.WriteLine("Selecciona la tarea a borrar:");

                        listaPendientes.MostrarTareasPorCompletar();
                        
                        int registroABorrar = int.Parse(Console.ReadLine());

                        listaPendientes.BorrarTareaPorCompletar(registroABorrar);

                    }

                    else if (opcionABorrar == "2")
                    {
                        Console.WriteLine("Selecciona la tarea a borrar:");

                        listaPendientes.MostrarTareasCompletadas();                     
                                
                        int registroABorrar = int.Parse(Console.ReadLine());

                        registroCompletados.BorrarTareaCompletada(registroABorrar);                            
                    }               
                }

                else if(opcion == "5")
                {
                    Console.WriteLine("Exportando documento...");
                    listaPendientes.Exportar();                           
                }

                else if (opcion == "9")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Saliendo del programa...");
                }

                

            }
        }
    }
}
