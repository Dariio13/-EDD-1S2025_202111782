using System;
using System.Text; // Necesario para construir la cadena de salida
using System.IO;
using System.Diagnostics;
using Estructuras;


namespace Estructuras
{
    // Definición de la clase Servicio
    public class Servicio
    {
        public int ID { get; set; }
        public int ID_Orden { get; set; }
        public double Total { get; set; }

        public Servicio(int id, int idOrden, double total)
        {
            ID = id;
            ID_Orden = idOrden;
            Total = total;
        }
    }

    // Definición de la clase Nodo
    public class Nodo
    {
        public Servicio Data;  // Ahora almacena un objeto Servicio
        public Nodo Sig;       // Apunta al siguiente nodo

        public Nodo(Servicio servicio)
        {
            Data = servicio;
            Sig = null;
        }
    }

    public class Pila
    {
        private Nodo tope; // Apunta al nodo superior de la pila
        private int count; // Lleva la cuenta de los elementos en la pila

        public Pila()
        {
            tope = null;
            count = 0;
        }

        // Propiedad para obtener el número de elementos en la pila
        public int Count => count;

        // Método Push: agrega un nuevo nodo al tope de la pila
        public void Push(Servicio servicio)
        {
            Nodo nuevoNodo = new Nodo(servicio); // Crea un nuevo nodo con el servicio
            nuevoNodo.Sig = tope; // Apunta al nodo anterior
            tope = nuevoNodo; // El nuevo nodo es ahora el tope de la pila
            count++; // Incrementa el contador
        }

        // Método Pop: elimina y devuelve el servicio en el nodo superior
        public Servicio Pop()
        {
            if (tope == null) return null; // Si la pila está vacía, retorna null
            Servicio ret = tope.Data; // Guarda el servicio en el nodo superior
            tope = tope.Sig; // El tope pasa al siguiente nodo
            count--; // Decrementa el contador
            return ret; // Retorna el servicio eliminado
        }

        // Método Peek: retorna el servicio en el tope sin eliminarlo
        public Servicio Peek()
        {
            if (tope == null) return null; // Si la pila está vacía, retorna null
            return tope.Data; // Retorna el servicio en el tope
        }

        // Método MostrarPila: retorna una cadena con los valores de la pila
        public string MostrarPila()
        {
            if (tope == null)
                return "La pila está vacía.";

            StringBuilder sb = new StringBuilder();
            Nodo temp = tope;
            sb.AppendLine("Contenido de la pila:");

            while (temp != null)
            {
                sb.AppendLine($"ID: {temp.Data.ID}, ID_Orden: {temp.Data.ID_Orden}, Total: {temp.Data.Total:C2}");
                temp = temp.Sig;
            }

            return sb.ToString();
        }

        // Método Print: imprime los valores de la pila en la consola
        public void Print()
        {
            Console.WriteLine(MostrarPila());
        }

        // Generar Graphviz para la pila
        public void GenerarGraphviz(string rutaArchivo)
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía.");
                return;
            }

            // Crear el código DOT
            StringBuilder dotCode = new StringBuilder();
            dotCode.AppendLine("digraph Pila {");
            dotCode.AppendLine("  rankdir=TB;");  // Organizar los nodos de arriba hacia abajo
            dotCode.AppendLine("  node [shape=record, width=.1];"); // Establecer formato para los nodos

            Nodo temp = tope;
            while (temp != null)
            {
                // Crear nodo para cada servicio en la pila
                dotCode.AppendLine($"  {temp.Data.ID} [label=\"Factura: {temp.Data.ID}\\nID_Orden: {temp.Data.ID_Orden}\\nTotal: {temp.Data.Total:C2}\"];");

                // Crear enlace hacia el siguiente nodo
                if (temp.Sig != null)
                {
                    dotCode.AppendLine($"  {temp.Data.ID} -> {temp.Sig.Data.ID};");
                }

                temp = temp.Sig;
            }

            dotCode.AppendLine("}");

            // Guardar el código DOT en un archivo
            try
            {
                File.WriteAllText(rutaArchivo, dotCode.ToString());
                Console.WriteLine("Archivo DOT generado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
        }

        // Generar la imagen a partir del archivo DOT
        public void GenerarImagenGraphviz(string rutaArchivoDot, string rutaImagen)
        {
            try
            {
                ProcessStartInfo proceso = new ProcessStartInfo
                {
                    FileName = "dot",
                    Arguments = $"-Tpng {rutaArchivoDot} -o {rutaImagen}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process p = Process.Start(proceso))
                {
                    p.WaitForExit();
                    Console.WriteLine("Imagen generada correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar la imagen: {ex.Message}");
            }
        }
    }
}
