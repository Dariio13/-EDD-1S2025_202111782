using Gtk;
using System;

public class Menu : Window
{
    private ListBox listBox;
    //private IngresoManual ingresoManual1;
    private ListaUsuarios listaUsuarios;
    private ListaDoble listaVehiculos;

    public Menu(ListaUsuarios listaUsuarios, ListaDoble listaVehiculos) : base("Menú")
    {
        this.listaUsuarios = listaUsuarios; // Usar la lista pasada en el constructor
        this.listaVehiculos = listaVehiculos;
        SetDefaultSize(300, 200);
        SetPosition(WindowPosition.Center);

        Box vbox = new Box(Orientation.Vertical, 10);
        vbox.Margin = 10;

        listBox = new ListBox();
        listBox.SelectionMode = SelectionMode.Single;

        // Crear y agregar opciones al ListBox con botones
        AddRow("Cargas Masivas", OnCargasMasivasClicked);
        AddRow("Ingreso Individual", OnIngresoIndividualClicked);
        AddRow("Gestión de Usuarios", OnGestionUsuariosClicked);
        AddRow("Generar Servicio", OnGenerarServicioClicked);
        AddRow("Cancelar Factura", OnCancelarFacturaClicked);

        vbox.PackStart(listBox, true, true, 0);
        Add(vbox);

        ShowAll();
    }

    private void AddRow(string text, EventHandler onClick)
    {
        ListBoxRow row = new ListBoxRow();
        Button button = new Button(text);
        button.Clicked += onClick;
        row.Add(button);
        listBox.Add(row);
    }

    // Métodos de eventos para los botones (puedes personalizar la lógica)
    private void OnCargasMasivasClicked(object sender, EventArgs e)
    {
        CargasMasivas cargasMasivas = new CargasMasivas(listaUsuarios);
        cargasMasivas.ShowAll();
        this.Hide();
        Console.WriteLine("Cargas Masivas seleccionado");
    }

    private void OnIngresoIndividualClicked(object sender, EventArgs e)
    {
        IngresoManual ingresoManual = new IngresoManual(listaUsuarios, listaVehiculos);
        this.Hide();
        ingresoManual.Show();
        Console.WriteLine("Ingreso Individual seleccionado");
    }

    private void OnGestionUsuariosClicked(object sender, EventArgs e)
    {
        GestionUsuarios gestionUsuarios = new GestionUsuarios(listaUsuarios, listaVehiculos);
        this.Hide();
        gestionUsuarios.Show();
        Console.WriteLine("Gestión de Usuarios seleccionado");
    }

    private void OnGenerarServicioClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Generar Servicio seleccionado");
    }

    private void OnCancelarFacturaClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Cancelar Factura seleccionado");
    }

}
