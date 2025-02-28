using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using Estructuras;


// Clase Repuesto que contiene los datos de cada repuesto
public class Repuesto
{
    public int ID { get; set; }
    public string Repuestos { get; set; }
    public string Detalles { get; set; }
    public double Costo { get; set; }
}

// Clase NodoCircular que representa cada nodo en la lista circular
public class NodoCircular
{
    public Repuesto Datos;
    public NodoCircular Siguiente;

    public NodoCircular(Repuesto repuesto)
    {
        Datos = repuesto;
        Siguiente = null;
    }
}

// Clase ListaCircular que contiene la lógica para manejar la lista circular de repuestos
public class ListaCircular
{
    private NodoCircular cabeza;
    private NodoCircular ultimo;

    public ListaCircular()
    {
        cabeza = null;
        ultimo = null;
    }

    // Método público para obtener la cabeza
    public NodoCircular ObtenerCabeza()
    {
        return cabeza;
    }


    // Agregar un repuesto a la lista
    public void Agregar(Repuesto repuesto)
    {
        NodoCircular nuevoNodo = new NodoCircular(repuesto);

        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            ultimo = nuevoNodo;
            nuevoNodo.Siguiente = cabeza;  // Hacemos circular el último nodo apuntando al primero
        }
        else
        {
            ultimo.Siguiente = nuevoNodo;
            ultimo = nuevoNodo;
            ultimo.Siguiente = cabeza;  // El último nodo vuelve a apuntar al primero
        }
    }

    // Mostrar todos los repuestos de la lista circular
    public void MostrarRepuestos()
    {
        if (cabeza != null)
        {
            NodoCircular actual = cabeza;
            do
            {
                Console.WriteLine($"ID: {actual.Datos.ID}, Repuesto: {actual.Datos.Repuestos}, Detalles: {actual.Datos.Detalles}, Costo: {actual.Datos.Costo}");
                actual = actual.Siguiente;
            } while (actual != cabeza);  // Detenemos cuando llegamos al primer nodo
        }
        else
        {
            Console.WriteLine("La lista está vacía.");
        }
    }

    // Cargar los repuestos desde un archivo JSON
    public void CargarDesdeJson(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            List<Repuesto> repuestos = JsonConvert.DeserializeObject<List<Repuesto>>(json);

            foreach (Repuesto repuesto in repuestos)
            {
                Agregar(repuesto);
            }
        }
        else
        {
            Console.WriteLine("El archivo JSON no existe.");
        }
    }

    // Generar Graphviz para la lista circular
    public void GenerarGraphviz(string rutaArchivo)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        // Crear el código DOT
        string dotCode = "digraph ListaRepuestos {\n";
        dotCode += "  rankdir=LR;\n";  // Para que los nodos se organicen de forma horizontal

        NodoCircular actual = cabeza;
        do
        {
            // Nodo para el repuesto
            dotCode += $"  {actual.Datos.ID} [label=\"ID: {actual.Datos.ID}\n Repuesto: {actual.Datos.Repuestos}\n Detalles: {actual.Datos.Detalles}\n Costo: {actual.Datos.Costo} \"];\n";

            // Enlace al siguiente nodo (flecha del nodo actual al siguiente)
            if (actual.Siguiente != cabeza)  // Solo agregamos enlace si no estamos en el último nodo
            {
                dotCode += $"  {actual.Datos.ID} -> {actual.Siguiente.Datos.ID};\n";
            }

            actual = actual.Siguiente;
        } while (actual != cabeza);  // Detenemos cuando llegamos al primer nodo

        // Cerrar el ciclo (hacer que el último nodo apunte al primero)
        dotCode += $"  {ultimo.Datos.ID} -> {cabeza.Datos.ID};\n";

        dotCode += "}\n";

        // Guardar el código DOT en un archivo
        try
        {
            File.WriteAllText(rutaArchivo, dotCode);
            Console.WriteLine("Archivo DOT generado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
        }
    }

    // Generar la imagen a partir del archivo DOT
    public void GenerarImagenGraphviz(string nombreArchivoDot, string nombreImagen)
    {
        try
        {
            // Comando para generar la imagen con Graphviz
            string comando = $"dot -Tpng {nombreArchivoDot} -o {nombreImagen}";

            // Crear proceso para ejecutar el comando
            ProcessStartInfo procesoInfo = new ProcessStartInfo("/bin/bash", $"-c \"{comando}\"")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proceso = new Process { StartInfo = procesoInfo })
            {
                proceso.Start();
                proceso.WaitForExit();

                // Leer salida y errores si los hay
                string salida = proceso.StandardOutput.ReadToEnd();
                string error = proceso.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"Error al generar la imagen: {error}");
                }
                else
                {
                    Console.WriteLine("Imagen generada correctamente.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el proceso de generación de imagen: {ex.Message}");
        }
    }


}


