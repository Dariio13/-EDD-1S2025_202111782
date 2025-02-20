using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
}
