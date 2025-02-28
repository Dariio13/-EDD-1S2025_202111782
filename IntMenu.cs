using Estructuras;
using Gtk;
using System;

public class Menu : Window
{
    private ListBox listBox;
    private ListaUsuarios listaUsuarios;
    private ListaDoble listaVehiculos;
    private ListaCircular listaRepuestos;
    private Pila pilaServicios;
    private Cola colaServicios;

    public Menu(ListaUsuarios listaUsuarios, ListaDoble listaVehiculos, ListaCircular listaRepuestos, Pila pilaServicios, Cola colaServicios) : base("Menú")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;
        this.listaRepuestos = listaRepuestos;
        this.pilaServicios = pilaServicios;
        this.colaServicios = colaServicios;
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
        AddRow("Reportes", OnReportesClicked);

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

    // Métodos de eventos para los botones
    private void OnCargasMasivasClicked(object sender, EventArgs e)
    {
        CargasMasivas cargasMasivas = new CargasMasivas(listaUsuarios);
        cargasMasivas.ShowAll();
        this.Hide();
        Console.WriteLine("Cargas Masivas seleccionado");
    }

    private void OnIngresoIndividualClicked(object sender, EventArgs e)
    {
        IngresoManual ingresoManual = new IngresoManual(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios);
        this.Hide();
        ingresoManual.Show();
        Console.WriteLine("Ingreso Individual seleccionado");
    }

    private void OnGestionUsuariosClicked(object sender, EventArgs e)
    {
        GestionUsuarios gestionUsuarios = new GestionUsuarios(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios);
        this.Hide();
        gestionUsuarios.Show();
        Console.WriteLine("Gestión de Usuarios seleccionado");
    }

    private void OnGenerarServicioClicked(object sender, EventArgs e)
    {
        GenerarServicio generarServicio = new GenerarServicio(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios);
        this.Hide();
        generarServicio.Show();
        Console.WriteLine("Generar Servicio seleccionado");
    }

    private void OnCancelarFacturaClicked(object sender, EventArgs e)
    {
        if (pilaServicios.Count > 0)
        {
            Factura factura = new Factura(pilaServicios);
            factura.ShowAll();
            this.Hide();
        }
        else
        {
            Console.WriteLine("No hay facturas en la pila.");
        }
    }

    private void OnReportesClicked(object sender, EventArgs e)
    {
        /*listaUsuarios.GenerarGraphviz("ListaSimple.dot");
        listaUsuarios.GenerarImagenGraphviz("ListaSimple.dot", "usuarios.png");

        listaVehiculos.GenerarGraphviz("vehiculos.dot");
        listaVehiculos.GenerarImagenGraphviz("vehiculos.dot", "vehiculos.png");

        listaRepuestos.GenerarGraphviz("ListaCircular.dot");
        listaRepuestos.GenerarImagenGraphviz("ListaCircular.dot", "repustos.png");*/

        colaServicios.GenerarGraphviz("Cola.dot");
        colaServicios.GenerarImagenGraphviz("Cola.dot", "servicios.png");

        /*pilaServicios.GenerarGraphviz("Pila.dot");
        pilaServicios.GenerarImagenGraphviz("Pila.dot", "facturas.png");*/
    }
}
