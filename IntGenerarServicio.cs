using Estructuras;
using Gtk;
using System;

public class GenerarServicio : Window
{
    private Entry idEntry, idRepuestoEntry, idVehiculoEntry, detallesEntry, costoEntry;
    private Button guardarButton;
    private ListaUsuarios listaUsuarios;  
    private ListaDoble listaVehiculos;
    private ListaCircular listaRepuestos;
    private Cola colaServicios = new Cola();
    private Pila pilaServicios = new Pila();

    /*public class Servicio
    {
        public int ID { get; set; }
        public int ID_Orden { get; set; }
        public double Total { get; set; }

        public Servicio(int id, int idOrden, double total)
        {
            ID = id;
            ID_Orden = idOrden;
            Total = total;
        }
    }*/

    public GenerarServicio(ListaUsuarios listaUsuarios, ListaDoble listaVehiculos, ListaCircular listaRepuestos, Pila pilaServicios, Cola colaServicios) 
        : base("Generar Servicio")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;
        this.listaRepuestos = listaRepuestos;
        this.pilaServicios = pilaServicios;
        this.colaServicios = colaServicios;
        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        Grid grid = new Grid { ColumnSpacing = 10, RowSpacing = 10, Margin = 15 };

        // Fila 1: ID
        grid.Attach(new Label("ID:"), 0, 0, 1, 1);
        idEntry = new Entry();
        grid.Attach(idEntry, 1, 0, 1, 1);

        // Fila 2: ID Repuesto
        grid.Attach(new Label("ID Repuesto:"), 0, 1, 1, 1);
        idRepuestoEntry = new Entry();
        grid.Attach(idRepuestoEntry, 1, 1, 1, 1);

        // Fila 3: ID Vehículo
        grid.Attach(new Label("ID Vehículo:"), 0, 2, 1, 1);
        idVehiculoEntry = new Entry();
        grid.Attach(idVehiculoEntry, 1, 2, 1, 1);

        // Fila 4: Detalles
        grid.Attach(new Label("Detalles:"), 0, 3, 1, 1);
        detallesEntry = new Entry();
        grid.Attach(detallesEntry, 1, 3, 1, 1);

        // Fila 5: Costo
        grid.Attach(new Label("Costo:"), 0, 4, 1, 1);
        costoEntry = new Entry();
        grid.Attach(costoEntry, 1, 4, 1, 1);

        // Fila 6: Botón Guardar
        guardarButton = new Button("Guardar");
        guardarButton.Clicked += OnGuardarClicked;
        grid.Attach(guardarButton, 1, 5, 1, 1);

        // Fila 6: Botón Regresar
        Button btnRegresar = new Button("Regresar");
        btnRegresar.Clicked += OnRegresarClicked;
        grid.Attach(btnRegresar, 2, 5, 1, 1);

        Add(grid);
        ShowAll();
    }

    private void OnGuardarClicked(object sender, EventArgs e)
    {
        string id = idEntry.Text;
        string idRepuesto = idRepuestoEntry.Text;
        string idVehiculo = idVehiculoEntry.Text;
        string detalles = detallesEntry.Text;
        string costoStr = costoEntry.Text;

        // Verificar si el ID de repuesto existe y obtener su costo
        bool repuestoExiste = false;
        double costoRepuesto = 0;
        NodoCircular actualRepuesto = listaRepuestos.ObtenerCabeza();

        if (actualRepuesto != null)
        {
            do
            {
                if (actualRepuesto.Datos.ID.ToString() == idRepuesto)
                {
                    repuestoExiste = true;
                    costoRepuesto = actualRepuesto.Datos.Costo; // Obtener costo del repuesto
                    break;
                }
                actualRepuesto = actualRepuesto.Siguiente;
            } while (actualRepuesto != listaRepuestos.ObtenerCabeza());
        }

        // Verificar si el ID de vehículo existe
        bool vehiculoExiste = false;
        NodoDoble actualVehiculo = listaVehiculos.ObtenerCabeza();

        while (actualVehiculo != null)
        {
            if (actualVehiculo.Datos.ID.ToString() == idVehiculo)
            {
                vehiculoExiste = true;
                break;
            }
            actualVehiculo = actualVehiculo.Siguiente;
        }

        // Validar existencia de repuesto y vehículo
        if (!repuestoExiste && !vehiculoExiste)
        {
            Console.WriteLine("El repuesto y el vehículo no existen.");
            return;
        }
        if (!repuestoExiste)
        {
            Console.WriteLine("El repuesto no existe.");
            return;
        }
        if (!vehiculoExiste)
        {
            Console.WriteLine("El vehículo no existe.");
            return;
        }

        // Convertir el costo ingresado a número
        if (!double.TryParse(costoStr, out double costoIngresado))
        {
            Console.WriteLine("Error: El costo ingresado no es un número válido.");
            return;
        }

        // Calcular el total del servicio
        double total = costoIngresado + costoRepuesto;

        Console.WriteLine($"Servicio guardado: ID={id}, ID_Repuesto={idRepuesto}, ID_Vehiculo={idVehiculo}, Detalles={detalles}, Costo={costoIngresado}, Total={total}");

        // Encolar el ID del servicio
        colaServicios.Encolar(int.Parse(id));
        Console.WriteLine($"ID del servicio {id} ha sido agregado a la cola.");

        // Apilar el servicio con ID, ID_Orden (igual al ID) y Total
        //Servicio nuevoServicio = new Servicio(int.Parse(id), int.Parse(id), total);
        Estructuras.Servicio nuevoServicio = new Estructuras.Servicio(int.Parse(id), int.Parse(id), total);
        pilaServicios.Push(nuevoServicio);
        Console.WriteLine($"Factura con ID {id} apilado con total {total}.");
    }


    private void OnRegresarClicked(object sender, EventArgs e)
    {
        // Asegúrate de pasar la pilaServicios al crear el objeto Menu
        Menu menu = new Menu(listaUsuarios, listaVehiculos, listaRepuestos, pilaServicios, colaServicios); 
        menu.ShowAll();
        this.Hide();
    }

}
