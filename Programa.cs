using System;
using Estructuras;
using Gtk;

class Program
{
    static void Main()
    {
        unsafe
        {
            Application.Init();
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            ListaDoble listaVehiculos = new ListaDoble();
            ListaCircular listaRepuesto = new ListaCircular();
            Cola colaServicios = new Cola();
            Pila pilaServicios = new Pila();

            // Mostrar usuarios después de la carga
            Console.WriteLine("\nMostrando Usuarios");
            listaUsuarios.MostrarUsuarios();
            Console.WriteLine("\nMostrando Vehiculos");
            listaVehiculos.MostrarVehiculos();
            Console.WriteLine("\nMostrando Repuestos");
            listaRepuesto.MostrarRepuestos();
            Console.WriteLine("\nMostrando Cola");
            colaServicios.MostrarCola();
            Console.WriteLine("\nMostrando Pila");
            pilaServicios.MostrarPila();

            // Crear la ventana principal
            IniciarSesion interfaz = new IniciarSesion();
            interfaz.ShowAll();

            Application.Run();

        }
    }
}
