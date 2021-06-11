using System;
using System.Collections.Generic;
using System.IO;

namespace PR3_ToDoList
{
    class ListaActividades
    {
        List<Registro> listaRegistros = new List<Registro>();
        List<Registro> registrosCompletados = new List<Registro>();

        // public Registro registro;
        // public string input;
        // public string fecha;

        public void Agregar(Registro registro)
        {
            this.listaRegistros.Add(registro);
        }

        public void MostrarTareasPorCompletar()
        {
            int i = 1;
            foreach (var registro in listaRegistros)
            {
                Console.WriteLine($"{i}.");
                Console.WriteLine($"Fecha: {registro.fecha}");
                Console.Write($"{registro.entry} ");
                Console.WriteLine("[]");
                
                Console.WriteLine("----------");

                i = i + 1;
            }
        }
        public void MostrarTareasCompletadas()
        {
            int i = 1;
            foreach (var registro in registrosCompletados)
            {
                Console.WriteLine($"{i}.");
                Console.WriteLine($"Fecha: {registro.fecha}");
                Console.Write($"{registro.entry} ");
                Console.WriteLine("[x]");
                
                Console.WriteLine("----------");

                i = i + 1;
            }
        }
        public void MostrarTodo()
        {
            Console.WriteLine("");
            Console.WriteLine("Lista de tareas:");
            Console.WriteLine("");

            if (listaRegistros.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes");
            }
            else
            {
                MostrarTareasPorCompletar();
            }

            Console.WriteLine("");           
            Console.WriteLine("Tareas completadas:");
            Console.WriteLine("");

            if (registrosCompletados.Count == 0)
            {
                Console.WriteLine("No hay tareas completadas");
            }            
            else
            {
                MostrarTareasCompletadas();
            }          
        }
        public void CompletarTarea()
        {
            MostrarTareasPorCompletar();

            int tareaACompletar = int.Parse(Console.ReadLine());

            for (int i = 0; i < listaRegistros.Count; i++)
            {
                if(tareaACompletar == i)
                {
                    Registro tareCompletada = listaRegistros[i];
                    listaRegistros.Remove(listaRegistros[i]);

                    registrosCompletados.Add(tareCompletada);
                }
            }
        }


        public void BorrarTareaPorCompletar(int registroABorrar)
        {
            for(int i = 0; i < listaRegistros.Count; i++)
            {
                if(registroABorrar == i)
                {
                    listaRegistros.Remove(listaRegistros[i]);
                }
            }

        }
        public void BorrarTareaCompletada(int registroABorrar)
        {       
            for(int i = 0; i < registrosCompletados.Count; i++)
            {
                if(registroABorrar == i)
                {
                    registrosCompletados.Remove(registrosCompletados[i]);
                }
            }

        }

        public void Exportar()
        {
            using (StreamWriter sw = new StreamWriter("Actividades.txt"))
            {
                int i = 1;

                sw.WriteLine("");
                sw.WriteLine("Lista de Tareas");
                sw.WriteLine("");

                foreach (var registro in listaRegistros)
                {
                    sw.WriteLine($"{i}.");
                    sw.WriteLine($"Fecha: {registro.fecha}");
                    sw.Write($"{registro.entry} ");
                    sw.WriteLine("[]");
                    
                    sw.WriteLine("----------");

                    i = i + 1;
                }

                i = 1;

                sw.WriteLine("");           
                sw.WriteLine("Tareas completadas");
                sw.WriteLine("");

                foreach (var registro in registrosCompletados)
                {
                    sw.WriteLine($"{i}.");
                    sw.WriteLine($"Fecha: {registro.fecha}");
                    sw.Write($"{registro.entry} ");
                    sw.WriteLine("[x]");
                    
                    sw.WriteLine("----------");

                    i = i + 1;
                }

            }
        }


            
    }
}
