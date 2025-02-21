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

    // Ver usuario junto con sus vehículos
    public void VerUsuario(int id, ListaDoble listaVehiculos)
    {
        NodoSimple actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.ID == id)
            {
                Console.WriteLine($"ID: {actual.Datos.ID}");
                Console.WriteLine($"Nombre: {actual.Datos.Nombres} {actual.Datos.Apellidos}");
                Console.WriteLine($"Correo: {actual.Datos.Correo}");
                Console.WriteLine("Vehículos del usuario:");

                // Buscar los vehículos del usuario en la lista doblemente enlazada
                NodoDoble vehiculoActual = listaVehiculos.ObtenerCabeza();
                bool tieneVehiculos = false;

                while (vehiculoActual != null)
                {
                    if (vehiculoActual.Datos.ID_Usuario == id)
                    {
                        Console.WriteLine($"  - {vehiculoActual.Datos.Marca} ({vehiculoActual.Datos.Modelo}), Placa: {vehiculoActual.Datos.Placa}");
                        tieneVehiculos = true;
                    }
                    vehiculoActual = vehiculoActual.Siguiente;
                }

                if (!tieneVehiculos)
                {
                    Console.WriteLine("  No tiene vehículos registrados.");
                }

                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Usuario no encontrado.");
    }


    // Editar usuario
    public void EditarUsuario(int id, string nuevosNombres, string nuevosApellidos, string nuevoCorreo)
    {
        NodoSimple actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.ID == id)
            {
                actual.Datos.Nombres = nuevosNombres;
                actual.Datos.Apellidos = nuevosApellidos;
                actual.Datos.Correo = nuevoCorreo;
                Console.WriteLine("Usuario actualizado correctamente.");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Usuario no encontrado.");
    }

    // Eliminar usuario
    public void EliminarUsuario(int id)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Datos.ID == id)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine("Usuario eliminado correctamente.");
            return;
        }

        NodoSimple actual = cabeza;
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Datos.ID == id)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                Console.WriteLine("Usuario eliminado correctamente.");
                return;
            }
            actual = actual.Siguiente;
        }

        Console.WriteLine("Usuario no encontrado.");
    }
}
