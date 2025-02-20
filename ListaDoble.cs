using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
}
