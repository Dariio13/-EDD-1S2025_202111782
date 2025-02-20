using System;
using Gtk;

class Program
{
    static void Main()
    {
        unsafe
        {
            Application.Init();
            ListaUsuarios lista = new ListaUsuarios();
            ListaDoble listaVehiculos = new ListaDoble();
            ListaCircular listaRepuesto = new ListaCircular();

            /*// Agregar manualmente un usuario para probar
            lista.Agregar(new Usuario { ID = 1, Nombres = "Juan", Apellidos = "Pérez", Correo = "juan.perez@mail.com", Contrasenia = "123456" });

            // Mostrar usuarios después de agregar manualmente
            Console.WriteLine("Usuarios agregados manualmente:");
            lista.MostrarUsuarios();

            // Cargar desde JSON
            lista.CargarDesdeJson("Ejemplo.json");*/

            // Mostrar usuarios después de la carga
            Console.WriteLine("\nMostrando Usuarios");
            lista.MostrarUsuarios();
            Console.WriteLine("\nMostrando Vehiculos");
            listaVehiculos.MostrarVehiculos();
            Console.WriteLine("\nMostrando Repuestos");
            listaRepuesto.MostrarRepuestos();

            // Crear la ventana principal
            IniciarSesion interfaz = new IniciarSesion();
            interfaz.ShowAll();

            Application.Run();

        }
    }
}
