# Manual de Usuario - Sistema de Gestión de Servicios

Este es un sistema de gestión de usuarios, vehículos, repuestos y servicios en el cual puedes agregar, editar, eliminar y generar servicios para los usuarios. La aplicación está diseñada con una interfaz gráfica basada en **Gtk#** y permite realizar las siguientes acciones:

## Índice

1. [Ingreso Manual de Usuario](#ingreso-manual-de-usuario)
2. [Gestión de Usuarios](#gestión-de-usuarios)
3. [Generar Servicio](#generar-servicio)
4. [Menú Principal](#menú-principal)

---

## Ingreso Manual de Usuario

La opción "Ingreso Manual" permite agregar un nuevo usuario al sistema.

### Pasos para agregar un usuario:

1. Abre la ventana **Ingreso Manual**.
2. Ingresa los siguientes datos en los campos correspondientes:
   - **ID**: Un número único que identifica al usuario.
   - **Nombre**: El nombre del usuario.
   - **Apellido**: El apellido del usuario.
   - **Correo**: El correo electrónico del usuario.
   - **Contraseña**: La contraseña del usuario (oculta por seguridad).
   
3. Haz clic en el botón **Guardar** para agregar el usuario a la lista.
4. Si el **ID** ya está en uso o hay un error en los campos, aparecerá un mensaje de advertencia.

---

## Gestión de Usuarios

La opción "Gestión de Usuarios" permite visualizar, editar y eliminar usuarios del sistema.

### Pasos para gestionar un usuario:

1. Abre la ventana **Gestión de Usuarios**.
2. Ingresa el **ID** del usuario que deseas gestionar en el campo correspondiente.
3. Las siguientes acciones estarán disponibles:
   - **Ver Usuario**: Muestra los detalles del usuario (Nombre, Apellido, Correo).
   - **Editar Usuario**: Permite modificar los datos del usuario. Es necesario llenar los campos de **Nombres**, **Apellidos** y **Correo**.
   - **Eliminar Usuario**: Elimina al usuario del sistema.

Si el **ID** ingresado no es válido o no existe, el sistema mostrará un mensaje de error.

---

## Generar Servicio

La opción "Generar Servicio" permite crear un nuevo servicio para un usuario, asociando repuestos y vehículos.

### Pasos para generar un servicio:

1. Abre la ventana **Generar Servicio**.
2. Ingresa los siguientes datos en los campos correspondientes:
   - **ID**: El ID único del servicio.
   - **ID Repuesto**: El ID del repuesto a utilizar.
   - **ID Vehículo**: El ID del vehículo asociado al servicio.
   - **Detalles**: Detalles adicionales del servicio.
   - **Costo**: El costo del servicio ingresado.

3. Haz clic en el botón **Guardar** para guardar el servicio. El sistema:
   - Verifica si el repuesto y el vehículo existen.
   - Calcula el **total** del servicio, que es la suma del costo del repuesto y el costo ingresado.
   - El **ID** del servicio se encola en una cola y también se apila en una pila para un seguimiento posterior.

4. Si los datos son incorrectos o faltan, aparecerá un mensaje de advertencia.

---

## Menú Principal

El **Menú Principal** es la pantalla inicial de la aplicación, desde donde puedes acceder a las siguientes opciones:

- **Ingreso Manual**: Para agregar un nuevo usuario.
- **Gestión de Usuarios**: Para editar, eliminar o visualizar un usuario existente.
- **Generar Servicio**: Para generar un nuevo servicio asociado a un usuario.
- **Ver Servicios**: Para consultar los servicios generados.
  
Para navegar entre las diferentes opciones, utiliza los botones correspondientes en la interfaz.

---

## Recomendaciones

- Asegúrate de ingresar datos válidos y completos en los formularios.
- Los IDs deben ser únicos para cada usuario, repuesto y vehículo.
- Si tienes problemas con el sistema, verifica que los datos ingresados sean correctos.

---

## Resolución de Problemas

- **Problema**: No puedo guardar un usuario.
  - **Solución**: Verifica que el **ID** del usuario sea único y que todos los campos estén completos.
  
- **Problema**: El servicio no se guarda correctamente.
  - **Solución**: Asegúrate de que el **ID del repuesto** y el **ID del vehículo** existan y que el costo ingresado sea un número válido.

---

Este manual cubre los aspectos básicos de uso del sistema. Si necesitas más información o asistencia técnica, no dudes en contactar con el soporte.

