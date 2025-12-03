# To-Do List

## Descripción del Proyecto

Este proyecto es una **aplicación de login y gestión de tareas (CRUD)** desarrollada con **Angular 17+** en el frontend y **.NET 9** en el backend.
Actualmente, el proyecto incluye:

* Una interfaz de **login en Angular** que permite ingresar email y contraseña.
* Una pantalla de **gestión de tareas (CRUD)** donde se pueden agregar y eliminar tareas.
* Un backend en **.NET 9** con endpoints `/login` y `/todo` para la gestión de usuarios y tareas.
* Pruebas del backend realizadas con **Swagger**, funcionando de manera independiente.

**Nota:** La conexión directa entre frontend y backend aún no está completamente establecida, por lo que algunas funcionalidades pueden estar simuladas o en desarrollo.

---

## Decisiones Técnicas

### Frontend

* **Framework:** Angular 17+
* **Componentes:**

  * `login.ts` → Pantalla de inicio de sesión.
  * `crud.ts` → Pantalla para **gestión de tareas (CRUD)**.
* **Standalone Components:** Permite usar componentes independientes sin necesidad de un módulo global.
* **FormsModule y CommonModule:** Para manejar formularios y directivas básicas.
* **SCSS:** Para los estilos de los componentes.
* **Rutas:** Configuración en `app.routes.ts` para navegar entre login, task-list y CRUD.

### Backend

* **Framework:** .NET 9
* **API RESTful:**

  * `/login` → Validación de email y contraseña.
  * `/tasks` → Endpoints para crear, leer, actualizar y eliminar tareas.
* **Autenticación básica:** Validación en memoria (simulada).
* **Swagger:** Para probar los endpoints de login y CRUD de forma interactiva y verificar respuestas.

---

## Cómo ejecutar el proyecto

### Backend (.NET 9)

1. Abrir la carpeta del backend en la terminal.
2. **Restaurar dependencias:**

```bash
dotnet restore
```

3. **Compilar el proyecto:**

```bash
dotnet build
```

4. **Ejecutar el backend:**

```bash
dotnet run
```

* La API estará disponible en `http://localhost:5026`.
* Abrir Swagger en `http://localhost:5026/swagger` para probar los endpoints `/login` y `/tasks`.

---

### Frontend (Angular 17+)

1. Abrir la carpeta del frontend en la terminal.
2. **Instalar dependencias:**

```bash
npm install
```

3. **Ejecutar la aplicación Angular:**

```bash
ng serve -o
```

* Angular abrirá automáticamente la aplicación en `http://localhost:4200`.
* Actualmente, el login funciona en la interfaz y la pantalla **CRUD** permite agregar, editar y eliminar tareas localmente.

---

## Cómo probar la funcionalidad

### Backend

* Usar **Swagger** para enviar solicitudes a los endpoints `/login` y `/tasks`.
* Verificar respuestas y la correcta gestión de tareas.

### Frontend

* Probar la interfaz de **login**: permite ingresar email y contraseña.
* Navegar a la pantalla **task-list** y la pantalla **CRUD** para gestionar tareas.
* Todas las operaciones CRUD pueden probarse localmente antes de integrar completamente con la API.

