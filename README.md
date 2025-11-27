**To-Do List**

**Descripción del Proyecto**

Este proyecto es una aplicación de login desarrollada con Angular 17+ en el frontend y .NET 9 en el backend.
Actualmente, el proyecto incluye:

Una interfaz de login en Angular que permite ingresar email y contraseña.

Un backend en .NET 9 con un endpoint /login que valida credenciales.

Pruebas del backend realizadas con Swagger, funcionando de manera independiente.

Nota: La conexión directa entre frontend y backend aún no está funcionando, por lo que la interfaz de login no puede validar usuarios en tiempo real contra la API.

**Decisiones Técnicas**

**Frontend**

**Framework:** Angular 17+

**Componentes:**

login.ts → pantalla de inicio de sesión.

task-list.ts → pantalla de bienvenida post-login.

**Standalone Components:** Permite usar componentes independientes sin necesidad de un módulo global.

**FormsModule y CommonModule:** Para manejar formularios y directivas básicas.

**SCSS:** Para los estilos de los componentes.

**Backend**

**Framework:** .NET 9

**API RESTful:** Endpoint /login para validar email y contraseña.

**Autenticación básica:** Validación en memoria (simulada).

**Swagger:** Para probar los endpoints de login de forma interactiva y verificar respuestas.

Cómo ejecutar el proyecto
Backend (.NET 9)

Abrir la carpeta del backend en la terminal.

**Restaurar dependencias:**

dotnet restore


**Compilar el proyecto:**

dotnet build


**Ejecutar el backend:**

dotnet run


La API estará disponible en http://localhost:5026.

Abrir Swagger en http://localhost:5026/swagger para probar el login enviando email y contraseña.

Frontend (Angular 17+)

Abrir la carpeta del frontend en la terminal.

**Instalar dependencias:**

npm install


**Ejecutar la aplicación Angular:**

ng serve -o


Angular abrirá automáticamente la aplicación en http://localhost:4200.

Actualmente, el login funciona en la interfaz, pero no se conecta al backend.

**Cómo probar la funcionalidad**

**Backend:** Usar Swagger para enviar solicitudes al endpoint /login y verificar respuestas.

**Frontend:** Probar la interfaz de login; permite ingresar email y contraseña, y navegar a la pantalla de bienvenida (task-list) de forma local.

Backend: Usar Swagger para enviar solicitudes al endpoint /login y verificar respuestas.

Frontend: Probar la interfaz de login; permite ingresar email y contraseña, y navegar a la pantalla de bienvenida (task-list) de forma local.
