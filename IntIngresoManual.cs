using Estructuras;
using Gtk;
using System;

public class IngresoManual : Window
{
    private Entry idEntry, nombreEntry, apellidoEntry, correoEntry, contrasenaEntry;
    private Button guardarButton;
    private ListaUsuarios listaUsuarios;
    private ListaDoble listaVehiculos;
    private ListaCircular listaRepuestos;
    private Pila pilaServicios;
    private Cola colaServicios;

    public IngresoManual(ListaUsuarios listaUsuarios, ListaDoble listaVehiculos, ListaCircular listaRepuestos, Pila pilaServicios, Cola colaServicios) : base("Ingreso Manual")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;  
        this.listaRepuestos = listaRepuestos;
        this.pilaServicios = pilaServicios;
        this.colaServicios = colaServicios;
        SetDefaultSize(300, 250);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        Box vbox = new Box(Orientation.Vertical, 10);
        vbox.Margin = 10;
        
        vbox.PackStart(new Label("ID:"), false, false, 0);
        idEntry = new Entry();
        vbox.PackStart(idEntry, false, false, 0);
        
        vbox.PackStart(new Label("Nombre:"), false, false, 0);
        nombreEntry = new Entry();
        vbox.PackStart(nombreEntry, false, false, 0);
        
        vbox.PackStart(new Label("Apellido:"), false, false, 0);
        apellidoEntry = new Entry();
        vbox.PackStart(apellidoEntry, false, false, 0);
        
        vbox.PackStart(new Label("Correo:"), false, false, 0);
        correoEntry = new Entry();
        vbox.PackStart(correoEntry, false, false, 0);
        
        vbox.PackStart(new Label("Contraseña:"), false, false, 0);
        contrasenaEntry = new Entry();
        contrasenaEntry.Visibility = false; // Para ocultar la contraseña
        vbox.PackStart(contrasenaEntry, false, false, 0);
        
        guardarButton = new Button("Guardar");
        guardarButton.Clicked += OnGuardarClicked;
        vbox.PackStart(guardarButton, false, false, 0);

        Button btnRegresar = new Button("Regresar");
        btnRegresar.Clicked += OnRegresarClicked;
        vbox.PackStart(btnRegresar, false, false, 0);
        
        Add(vbox);
        ShowAll();
    }

    private void OnGuardarClicked(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(idEntry.Text, out id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Usuario nuevoUsuario = new Usuario
        {
            ID = id,
            Nombres = nombreEntry.Text,
            Apellidos = apellidoEntry.Text,
            Correo = correoEntry.Text,
            Contrasenia = contrasenaEntry.Text
        };

        listaUsuarios.Agregar(nuevoUsuario);
        Console.WriteLine("Usuario agregado correctamente.");

        // Mostrar lista actualizada en la consola
        Console.WriteLine("Lista actualizada:");
        listaUsuarios.MostrarUsuarios();
    }


        private void OnRegresarClicked(object sender, EventArgs e)
    {
        Menu menu = new Menu(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios);
        menu.ShowAll();
        this.Hide();
    }

}
