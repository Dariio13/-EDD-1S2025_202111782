using Gtk;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;

public class CargasMasivas : Window
{
    private ComboBoxText comboBox;
    private ListaUsuarios listaUsuarios;  // Instancia de la lista enlazada
    private ListaDoble listaVehiculos;
    private ListaCircular listaRepuestos;

    public CargasMasivas() : base("Cargas Masivas")
    {
        SetDefaultSize(300, 200);
        SetPosition(WindowPosition.Center);

        // Inicializar la lista de usuarios
        listaUsuarios = new ListaUsuarios();
        listaVehiculos = new ListaDoble();
        listaRepuestos = new ListaCircular();

        // Contenedor principal (Box con orientación vertical)
        Box vbox = new Box(Orientation.Vertical, 10);
        vbox.Margin = 10;

        // Etiqueta descriptiva
        Label label = new Label("Seleccione una opción:");

        // ComboBox con opciones
        comboBox = new ComboBoxText();
        comboBox.AppendText("Usuarios");
        comboBox.AppendText("Vehículos");
        comboBox.AppendText("Repuestos");
        comboBox.Active = 0;

        // Botones
        Button btnCargar = new Button("Cargar");
        btnCargar.Clicked += OnCargarClicked;

        Button btnRegresar = new Button("Regresar");
        btnRegresar.Clicked += OnRegresarClicked;

        // Contenedor de botones
        Box buttonBox = new Box(Orientation.Horizontal, 10);
        buttonBox.PackStart(btnCargar, true, true, 0);
        buttonBox.PackStart(btnRegresar, true, true, 0);

        // Agregar elementos al contenedor principal
        vbox.PackStart(label, false, false, 0);
        vbox.PackStart(comboBox, false, false, 0);
        vbox.PackStart(buttonBox, false, false, 0);

        Add(vbox);
        ShowAll();
    }

    // Evento para el botón "Cargar"
    private void OnCargarClicked(object sender, EventArgs e)
    {
        string seleccion = comboBox.ActiveText;
        Console.WriteLine($"Cargando {seleccion}...");

        if (seleccion == "Usuarios")
        {
            // Ruta del archivo
            string filePath = "Usuarios.json";

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                try
                {
                    // Leer el contenido del archivo JSON
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserializar el JSON en una lista de usuarios
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonContent);

                    // Cargar los usuarios a la lista enlazada
                    foreach (var usuario in usuarios)
                    {
                        listaUsuarios.Agregar(usuario);
                    }

                    // Mostrar los usuarios cargados (esto es solo para verificar)
                    listaUsuarios.MostrarUsuarios();
                    Console.WriteLine("Usuarios cargados con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar el archivo JSON: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("El archivo Usuarios.json no existe.");
            }
        }

        if (seleccion == "Vehículos")
        {
            // Ruta del archivo
            string filePath = "Vehiculos.json";

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                try
                {
                    // Leer el contenido del archivo JSON
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserializar el JSON en una lista de vehículos
                    List<Vehiculo> vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(jsonContent);

                    // Cargar los vehículos a la lista doble
                    foreach (var vehiculo in vehiculos)
                    {
                        listaVehiculos.Agregar(vehiculo);
                    }

                    // Mostrar los vehículos cargados (esto es solo para verificar)
                    listaVehiculos.MostrarVehiculos();
                    Console.WriteLine("Vehículos cargados con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar el archivo JSON: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("El archivo Vehiculos.json no existe.");
            }
        }

        if (seleccion == "Repuestos")
        {
            // Ruta del archivo
            string filePath = "Repuestos.json";

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                try
                {
                    // Leer el contenido del archivo JSON
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserializar el JSON en una lista de repuestos
                    List<Repuesto> repuestos = JsonConvert.DeserializeObject<List<Repuesto>>(jsonContent);

                    // Cargar los repuestos a la lista circular
                    foreach (var repuesto in repuestos)
                    {
                        listaRepuestos.Agregar(repuesto);
                    }

                    // Mostrar los repuestos cargados (esto es solo para verificar)
                    listaRepuestos.MostrarRepuestos();
                    Console.WriteLine("Repuestos cargados con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar el archivo JSON: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("El archivo Repuestos.json no existe.");
            }
        }

    }

    // Evento para el botón "Regresar"
    private void OnRegresarClicked(object sender, EventArgs e)
    {
        Menu menu = new Menu();
        menu.ShowAll();
        this.Hide();
    }

}
