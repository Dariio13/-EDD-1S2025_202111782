using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

//Clase Usuario
public class Usuario
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Correo { get; set; }
    public string Contrasenia { get; set; }
}

public class NodoSimple
{
    public Usuario Datos;
    public NodoSimple Siguiente;

    public NodoSimple(Usuario usuario)
    {
        Datos = usuario;
        Siguiente = null;
    }
}



// ListaSimple
public class ListaUsuarios
{
    private NodoSimple cabeza;

    public ListaUsuarios()
    {
        cabeza = null;
    }

    //Agregar ususario
    public void Agregar(Usuario usuario)
    {
        NodoSimple nuevoNodo = new NodoSimple(usuario);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoSimple actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    //Mostrar usuario
    public void MostrarUsuarios()
    {
        NodoSimple actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"ID: {actual.Datos.ID}, Nombre: {actual.Datos.Nombres} {actual.Datos.Apellidos}, Correo: {actual.Datos.Correo}");
            actual = actual.Siguiente;
        }
    }

    //Carga masiva de usuarios
    public void CargarDesdeJson(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            foreach (Usuario usuario in usuarios)
            {
                Agregar(usuario);
            }
        }
        else
        {
            Console.WriteLine("El archivo JSON no existe.");
        }
    }
}
