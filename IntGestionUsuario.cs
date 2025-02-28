using Estructuras;
using Gtk;
using System;

public class GestionUsuarios : Window
{
    private Entry idEntry, nombreEntry, apellidoEntry, correoEntry;
    private Button verButton, editarButton, eliminarButton, regresarButton;
    private ListaUsuarios listaUsuarios;
    private ListaDoble listaVehiculos;
    private ListaCircular listaRepuestos;
    private Pila pilaServicios;
    private Cola colaServicios;

    public GestionUsuarios(ListaUsuarios listaUsuarios, ListaDoble listaVehiculos, ListaCircular listaRepuestos, Pila pilaServicios, Cola colaServicios) : base("Gestión de Usuarios")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;
        this.listaRepuestos = listaRepuestos;
        this.pilaServicios = pilaServicios;
        this.colaServicios = colaServicios;
        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        Grid grid = new Grid();
        grid.ColumnSpacing = 10;
        grid.RowSpacing = 10;
        grid.Margin = 15;

        // --- Fila 1: ID y botón "Ver" ---
        Label idLabel = new Label("ID del Usuario:");
        idEntry = new Entry();
        verButton = new Button("Ver Usuario");
        verButton.Clicked += OnVerUsuarioClicked;

        grid.Attach(idLabel, 0, 0, 1, 1);
        grid.Attach(idEntry, 1, 0, 1, 1);
        grid.Attach(verButton, 2, 0, 1, 1);

        // --- Fila 2: Botón "Eliminar" centrado debajo del ID ---
        eliminarButton = new Button("Eliminar Usuario");
        eliminarButton.Clicked += OnEliminarUsuarioClicked;
        grid.Attach(eliminarButton, 2, 1, 1, 1);

        // --- Fila 3: Campos de entrada ---
        Label nombreLabel = new Label("Nombres:");
        nombreEntry = new Entry();
        grid.Attach(nombreLabel, 0, 2, 1, 1);
        grid.Attach(nombreEntry, 1, 2, 1, 1);

        Label apellidoLabel = new Label("Apellidos:");
        apellidoEntry = new Entry();
        grid.Attach(apellidoLabel, 0, 3, 1, 1);
        grid.Attach(apellidoEntry, 1, 3, 1, 1);

        Label correoLabel = new Label("Correo:");
        correoEntry = new Entry();
        grid.Attach(correoLabel, 0, 4, 1, 1);
        grid.Attach(correoEntry, 1, 4, 1, 1);

        // --- Fila 4: Botón "Editar" a la derecha ---
        editarButton = new Button("Editar Usuario");
        editarButton.Clicked += OnEditarUsuarioClicked;
        grid.Attach(editarButton, 2, 3, 1, 1);

        // --- Fila 5: Botón "Regresar" al final ---
        regresarButton = new Button("Regresar");
        regresarButton.Clicked += OnRegresarClicked;
        grid.Attach(regresarButton, 1, 6, 1, 1);

        Add(grid);
        ShowAll();
    }

    private void OnVerUsuarioClicked(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(idEntry.Text, out id))
        {
            listaUsuarios.VerUsuario(id, listaVehiculos);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void OnEditarUsuarioClicked(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(idEntry.Text, out id))
        {
            if (string.IsNullOrWhiteSpace(nombreEntry.Text) || 
                string.IsNullOrWhiteSpace(apellidoEntry.Text) || 
                string.IsNullOrWhiteSpace(correoEntry.Text))
            {
                Console.WriteLine("Por favor complete todos los campos para editar.");
                return;
            }

            string nuevosNombres = nombreEntry.Text;
            string nuevosApellidos = apellidoEntry.Text;
            string nuevoCorreo = correoEntry.Text;
            listaUsuarios.EditarUsuario(id, nuevosNombres, nuevosApellidos, nuevoCorreo);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void OnEliminarUsuarioClicked(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(idEntry.Text, out id))
        {
            listaUsuarios.EliminarUsuario(id);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void OnRegresarClicked(object sender, EventArgs e)
    {
        Menu menu = new Menu(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios);
        menu.ShowAll();
        this.Hide();
    }
}
