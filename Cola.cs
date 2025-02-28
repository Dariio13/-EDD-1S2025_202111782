using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Estructuras;

public class NodoCola
{
    public int ID { get; set; } // Solo almacenamos el ID
    public NodoCola Siguiente { get; set; }

    public NodoCola(int id)
    {
        ID = id;
        Siguiente = null;
    }
}

public class Cola
{
    private NodoCola frente;
    private NodoCola final;

    public Cola()
    {
        frente = null;
        final = null;
    }

    // Método para encolar solo el ID
    public void Encolar(int id)
    {
        NodoCola nuevoNodo = new NodoCola(id);
        if (final == null)
        {
            frente = nuevoNodo;
            final = nuevoNodo;
        }
        else
        {
            final.Siguiente = nuevoNodo;
            final = nuevoNodo;
        }
    }

    // Método para desencolar y obtener el ID
    public int Desencolar()
    {
        if (frente == null)
        {
            Console.WriteLine("La cola está vacía.");
            return -1; // Devuelve -1 si la cola está vacía
        }

        int id = frente.ID; // Se obtiene solo el ID
        frente = frente.Siguiente;

        if (frente == null)
        {
            final = null;
        }

        return id;
    }

    // Método para imprimir la cola
    public void MostrarCola()
    {
        NodoCola actual = frente;
        while (actual != null)
        {
            Console.WriteLine($"ID: {actual.ID}");
            actual = actual.Siguiente;
        }
    }

    // Método para verificar si la cola está vacía
    public bool EstaVacia()
    {
        return frente == null;
    }

    // Generar archivo .dot para la representación de la cola
    public void GenerarGraphviz(string archivoDot)
    {
        using (StreamWriter writer = new StreamWriter(archivoDot))
        {
            writer.WriteLine("digraph Cola {");
            writer.WriteLine("rankdir=LR;");
            NodoCola actual = frente;
            while (actual != null)
            {
                // Escribir los nodos y las conexiones entre ellos
                if (actual.Siguiente != null)
                {
                    writer.WriteLine($"   ID_Servicio: {actual.ID} -> ID_Servicio: {actual.Siguiente.ID};");
                }
                else
                {
                    writer.WriteLine($"    {actual.ID};");
                }
                actual = actual.Siguiente;
            }
            writer.WriteLine("}");
        }
    }

    // Generar imagen a partir del archivo .dot
    public void GenerarImagenGraphviz(string archivoDot, string archivoImagen)
    {
        // Asegúrate de tener Graphviz instalado en tu sistema y disponible en el PATH.
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "dot", // Graphviz 'dot' command
            Arguments = $"-Tpng {archivoDot} -o {archivoImagen}",
            RedirectStandardOutput = true,
            RedirectStandardError = true, // Redirigir la salida de error
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = Process.Start(startInfo);
        
        // Leer la salida de error, si existe
        string errorOutput = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrEmpty(errorOutput))
        {
            Console.WriteLine("Error al generar la imagen:");
            Console.WriteLine(errorOutput);
        }
        else
        {
            Console.WriteLine("Imagen generada correctamente.");
        }
    }

}
