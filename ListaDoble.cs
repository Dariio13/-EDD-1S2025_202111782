using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using Estructuras;


// Clase Vehiculo
public class Vehiculo
{
    public int ID { get; set; }
    public int ID_Usuario { get; set; }
    public string Marca { get; set; }
    public int Modelo { get; set; }
    public string Placa { get; set; }
}

// Clase Nodo para la lista doblemente enlazada
public class NodoDoble
{
    public Vehiculo Datos;
    public NodoDoble Siguiente;
    public NodoDoble Anterior;

    public NodoDoble(Vehiculo vehiculo)
    {
        Datos = vehiculo;
        Siguiente = null;
        Anterior = null;
    }
}

// Clase ListaVehiculos para la lista doblemente enlazada
public class ListaDoble
{
    private NodoDoble cabeza;
    private NodoDoble cola;

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
    }

    // Método público para obtener la cabeza
    public NodoDoble ObtenerCabeza()
    {
        return cabeza;
    }


    // Agregar vehículo al final de la lista
    public void Agregar(Vehiculo vehiculo)
    {
        NodoDoble nuevoNodo = new NodoDoble(vehiculo);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = cola;
            cola = nuevoNodo;
        }
    }

    // Mostrar vehículos desde el inicio
    public void MostrarVehiculos()
    {
        NodoDoble actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"ID: {actual.Datos.ID}, ID_Usuario: {actual.Datos.ID_Usuario}, Marca: {actual.Datos.Marca}, Modelo: {actual.Datos.Modelo}, Placa: {actual.Datos.Placa}");
            actual = actual.Siguiente;
        }
    }

    // Mostrar vehículos desde el final
    public void MostrarVehiculosInverso()
    {
        NodoDoble actual = cola;
        while (actual != null)
        {
            Console.WriteLine($"ID: {actual.Datos.ID}, ID_Usuario: {actual.Datos.ID_Usuario}, Marca: {actual.Datos.Marca}, Modelo: {actual.Datos.Modelo}, Placa: {actual.Datos.Placa}");
            actual = actual.Anterior;
        }
    }

    // Cargar vehículos desde un archivo JSON
    public void CargarDesdeJson(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            List<Vehiculo> vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
            foreach (Vehiculo vehiculo in vehiculos)
            {
                Agregar(vehiculo);
            }
        }
        else
        {
            Console.WriteLine("El archivo JSON no existe.");
        }
    }

    // Generar Graphviz para la lista doble
    public void GenerarGraphviz(string rutaArchivo)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        // Crear el código DOT
        string dotCode = "digraph ListaVehiculos {\n";
        NodoDoble actual = cabeza;
        while (actual != null)
        {
            // Nodo para el vehículo
            dotCode += $"  {actual.Datos.ID} [label=\"ID: {actual.Datos.ID}\n ID_Usuario: {actual.Datos.ID_Usuario}\n Marca: {actual.Datos.Marca}\n Modelo: {actual.Datos.Modelo}\n Placa: {actual.Datos.Placa}\"];\n";

            // Enlace al siguiente nodo (flecha de cabeza a cola)
            if (actual.Siguiente != null)
            {
                dotCode += $"  {actual.Datos.ID} -> {actual.Siguiente.Datos.ID};\n";
            }

            // Enlace al nodo anterior (flecha de cola a cabeza)
            if (actual.Anterior != null)
            {
                dotCode += $"  {actual.Datos.ID} -> {actual.Anterior.Datos.ID} [dir=both, style=dotted];\n";
            }

            actual = actual.Siguiente;
        }
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
