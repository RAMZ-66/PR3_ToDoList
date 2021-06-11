using System;
using System.Globalization;
using System.IO;

namespace PR3_ToDoList
{
    class Registro
    {
        public string entry;
        public bool completado;
        public string fecha;

        public Registro(string entry, string fecha , bool completado)
        {
            this.completado = completado;
            this.entry = entry;
            this.fecha = fecha;
        }                 
    }
}
