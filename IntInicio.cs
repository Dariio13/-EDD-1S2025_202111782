using Gtk;
using System;

public class IniciarSesion : Window
{
    private Entry usuarioEntry;
    private Entry contrasenaEntry;

    public IniciarSesion() : base("Iniciar sesión")
    {
        SetDefaultSize(300, 200);
        SetPosition(WindowPosition.Center);

        // Crear un contenedor para los elementos
        Box vbox = new Box(Orientation.Vertical, 10);
        vbox.Margin = 10;


        // Label para usuario
        Label usuarioLabel = new Label("Usuario:");
        vbox.PackStart(usuarioLabel, false, false, 0);

        // Campo de texto para usuario
        usuarioEntry = new Entry();
        vbox.PackStart(usuarioEntry, false, false, 0);

        // Label para contraseña
        Label contrasenaLabel = new Label("Contraseña:");
        vbox.PackStart(contrasenaLabel, false, false, 0);

        // Campo de texto para contraseña (con máscara de caracteres)
        contrasenaEntry = new Entry();
        contrasenaEntry.Visibility = false;  // Ocultar caracteres
        vbox.PackStart(contrasenaEntry, false, false, 0);

        // Botón para ingresar
        Button goToInterface2Button = new Button("Ingresar");
        goToInterface2Button.Clicked += OnGoToInterface2ButtonClicked;
        vbox.PackStart(goToInterface2Button, false, false, 0);

        Add(vbox);
    }

    private void OnGoToInterface2ButtonClicked(object sender, EventArgs e)
    {
        string usuario = usuarioEntry.Text;
        string contrasena = contrasenaEntry.Text;

        // Validar el usuario y contraseña
        if (usuario == "root@gmail.com" && contrasena == "root123")
        {
            Console.WriteLine("Inicio de sesión exitoso");

            // Crear una lista de usuarios antes de abrir el menú
            ListaUsuarios lista = new ListaUsuarios();

            // Pasar la lista al menú
            Menu interface2 = new Menu();
            interface2.ShowAll();
            this.Hide(); // Ocultar la ventana de inicio de sesión
        }
        else
        {
            Console.WriteLine("Usuario o contraseña incorrectos");
        }
    }

}
