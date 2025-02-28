using Estructuras;
using Gtk;
using System;

public class Factura : Window
{
    private Label idLabel, idOrdenLabel, totalLabel;
    private Button siguienteButton, regresarButton;
    private Pila pilaServicios;
    private Estructuras.Servicio servicioActual;

    public Factura(Pila pila) : base("Factura")
    {
        this.pilaServicios = pila;

        SetDefaultSize(300, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += (o, args) => this.Hide(); // Oculta la ventana en vez de cerrar la app

        Box vbox = new Box(Orientation.Vertical, 10);
        vbox.Margin = 10;

        Label titulo = new Label("<b>Factura</b>") { UseMarkup = true };
        vbox.PackStart(titulo, false, false, 0);

        idLabel = new Label("ID: ");
        idOrdenLabel = new Label("ID_Orden: ");
        totalLabel = new Label("Total: ");
        vbox.PackStart(idLabel, false, false, 0);
        vbox.PackStart(idOrdenLabel, false, false, 0);
        vbox.PackStart(totalLabel, false, false, 0);

        siguienteButton = new Button("Siguiente");
        siguienteButton.Clicked += OnSiguienteClicked;
        vbox.PackStart(siguienteButton, false, false, 0);

        regresarButton = new Button("Regresar");
        regresarButton.Clicked += OnRegresarClicked;
        vbox.PackStart(regresarButton, false, false, 0);

        Add(vbox);
        MostrarFactura();
        ShowAll();
    }

    private void MostrarFactura()
    {
        // Verifica si hay facturas en la pila antes de mostrar
        if (pilaServicios.Count > 0)
        {
            servicioActual = pilaServicios.Peek(); // Ver el último elemento sin desapilarlo
            idLabel.Text = $"ID: {servicioActual.ID}";
            idOrdenLabel.Text = $"ID_Orden: {servicioActual.ID}"; // Se cambia a ID
            totalLabel.Text = $"Total: {servicioActual.Total:C2}";
        }
        else
        {
            idLabel.Text = "No hay más facturas en la pila.";
            idOrdenLabel.Hide();
            totalLabel.Hide();
            siguienteButton.Sensitive = false;
        }
    }

    private void OnSiguienteClicked(object sender, EventArgs e)
    {
        if (pilaServicios.Count > 0)
        {
            pilaServicios.Pop(); // Desapila el objeto actual
            MostrarFactura();    // Muestra el siguiente
        }
    }

    private void OnRegresarClicked(object sender, EventArgs e)
    {
        this.Hide(); // Oculta la ventana en vez de cerrarla
    }
}
