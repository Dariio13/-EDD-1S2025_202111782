# Manual Técnico del Proyecto: **Sistema de Gestión de Servicios**

## Descripción General

Este proyecto tiene como objetivo implementar un sistema de gestión de servicios, usuarios, vehículos y repuestos, usando estructuras de datos como listas, pilas, colas, y otras estructuras auxiliares. Está desarrollado en C# con el uso de Gtk para la interfaz gráfica, y permite gestionar información de usuarios, generar servicios, y realizar operaciones con las estructuras de datos mencionadas.

## Estructuras de Datos

### 1. **Lista Enlazada Simple (ListaUsuarios)**
Esta estructura almacena a los usuarios del sistema. Cada usuario tiene la siguiente información:

- ID
- Nombres
- Apellidos
- Correo
- Contraseña

La clase `ListaUsuarios` tiene las siguientes operaciones principales:
- **Agregar**: Añadir un usuario a la lista.
- **MostrarUsuarios**: Mostrar todos los usuarios almacenados en la lista.
- **VerUsuario**: Visualizar un usuario a partir de su ID.
- **EditarUsuario**: Editar la información de un usuario.
- **EliminarUsuario**: Eliminar un usuario de la lista.

### 2. **Lista Doble (ListaVehiculos)**
Esta estructura almacena los vehículos asociados a los usuarios. Cada vehículo tiene la siguiente información:

- ID
- Marca
- Modelo
- Año

Las operaciones en la lista doble son similares a las de la lista simple, permitiendo agregar, eliminar y mostrar vehículos.

### 3. **Lista Circular (ListaRepuestos)**
La lista circular almacena información sobre los repuestos disponibles para los servicios. Cada repuesto tiene los siguientes atributos:

- ID
- Nombre
- Costo

Al igual que las otras listas, se permiten las operaciones de agregar, eliminar y mostrar repuestos.

### 4. **Pila (PilaServicios)**
La pila almacena los servicios generados por los usuarios. Cada servicio tiene la siguiente información:

- ID
- ID de Orden (Igual al ID)
- Total (Costo del servicio más el costo del repuesto)

La pila permite apilar servicios y desapilar para ver los servicios anteriores.

### 5. **Cola (ColaServicios)**
La cola se utiliza para almacenar los IDs de los servicios generados. La operación principal es encolar el ID de cada nuevo servicio.

---

## Funcionalidades del Sistema

### 1. **Ingreso Manual de Usuarios (IngresoManual)**
Permite ingresar un nuevo usuario al sistema. El formulario solicita los siguientes datos:
- ID
- Nombre
- Apellido
- Correo
- Contraseña

Una vez ingresados los datos, el sistema los agrega a la lista de usuarios.

### 2. **Gestión de Usuarios (GestionUsuarios)**
Permite visualizar, editar y eliminar usuarios de la lista. Para realizar estas acciones, se necesita el ID del usuario.

Las opciones disponibles son:
- **Ver Usuario**: Muestra los detalles de un usuario.
- **Editar Usuario**: Permite editar la información del usuario.
- **Eliminar Usuario**: Elimina un usuario de la lista.

### 3. **Generar Servicio (GenerarServicio)**
Permite generar un nuevo servicio. Los datos requeridos son:
- ID del servicio
- ID de repuesto
- ID del vehículo
- Detalles del servicio
- Costo del servicio

El sistema valida la existencia de los repuestos y vehículos, y calcula el total del servicio (costo del servicio + costo del repuesto). Luego encola el ID del servicio en la cola y apila la información del servicio en la pila.

---

## Interfaz Gráfica

### Ingreso Manual de Usuarios

En la interfaz de **Ingreso Manual**, los usuarios pueden agregar nuevos usuarios al sistema. El formulario incluye campos de texto para ingresar el ID, nombre, apellido, correo y contraseña del usuario, junto con un botón "Guardar" para agregar el usuario.

### Gestión de Usuarios

La interfaz de **Gestión de Usuarios** permite a los administradores ver, editar y eliminar usuarios. Los usuarios pueden buscar por su ID, visualizar su información, editar sus datos, o eliminarlo del sistema.

### Generación de Servicio

La interfaz de **Generar Servicio** permite ingresar los detalles de un nuevo servicio, validando la existencia de repuestos y vehículos, y calculando el costo total del servicio. Al confirmar, el servicio es apilado y su ID es encolado.

---

## Consideraciones Técnicas

### Compilación y Ejecución

Este proyecto está diseñado para ser ejecutado en un entorno Linux con **Debian 12**. Para compilar y ejecutar el proyecto, sigue estos pasos:

1. Abre una terminal y navega al directorio del proyecto.
2. Ejecuta el siguiente comando para compilar el proyecto:

    ```bash
    dotnet build
    ```

3. Para ejecutar el proyecto:

    ```bash
    dotnet run
    ```

### Dependencias

El proyecto utiliza **Gtk#** para la creación de interfaces gráficas. Asegúrate de tener las siguientes dependencias instaladas:

- GtkSharp
- .NET SDK (compatible con Linux)

### Archivos y Directorios

El proyecto consta de los siguientes archivos clave:
- **Estructuras.cs**: Contiene las definiciones de las estructuras de datos (listas, pila, cola).
- **IngresoManual.cs**: Formulario para agregar usuarios.
- **GestionUsuarios.cs**: Formulario para gestionar usuarios.
- **GenerarServicio.cs**: Formulario para generar servicios.
- **Program.cs**: Punto de entrada del programa.
- **Menu.cs**: Menú principal para navegar entre opciones.

---

## Conclusión

Este sistema proporciona una solución robusta para la gestión de usuarios, vehículos y servicios, utilizando estructuras de datos avanzadas para almacenar y gestionar la información. La interfaz gráfica, basada en Gtk, ofrece una experiencia intuitiva para los usuarios finales. El proyecto es flexible y fácilmente extensible, permitiendo agregar más funcionalidades en el futuro.

