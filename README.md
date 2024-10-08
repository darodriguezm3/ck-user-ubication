Aquí tienes un **README** adecuado para tu proyecto de **API de registro de usuarios en .NET** utilizando **Docker** y desplegado en **Back4App**.

### **README.md**

```markdown
# User Registration API

## Descripción

Esta es una API de registro de usuarios construida con **ASP.NET Core** y **PostgreSQL**. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre usuarios y está diseñada para funcionar con **Stored Procedures** en la base de datos. El proyecto está configurado para ejecutarse dentro de un contenedor Docker y está desplegado en **Back4App Containers**.

## Características

- Registro de usuarios con nombre, teléfono, dirección y relación con un municipio.
- Validación de los datos ingresados utilizando **Data Annotations** de ASP.NET.
- Operaciones en base de datos realizadas a través de **Stored Procedures** en **PostgreSQL**.
- Despliegue mediante **Docker** en **Back4App Containers**.
- Documentación y pruebas expuestas mediante **Swagger**.

## Requisitos

- **.NET SDK 7.0** o superior.
- **Docker** instalado para la ejecución en contenedores.
- **PostgreSQL** para la base de datos.
- **Back4App Containers** para el despliegue en la nube.

## Configuración local

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/user-registration-api.git
cd user-registration-api
```

### 2. Configurar variables de entorno

Crea un archivo `.env` en el directorio raíz del proyecto para configurar las variables de entorno necesarias:

```bash
CONNECTION_STRING="Host=localhost;Database=MiBaseDeDatos;Username=postgres;Password=MiPassword"
PORT=3000
```

### 3. Ejecutar la API localmente

Para ejecutar la aplicación en tu máquina local:

```bash
dotnet build
dotnet run
```

La API estará disponible en `http://localhost:3000`.

### 4. Ejecutar la API en Docker

#### 4.1 Construir la imagen Docker

```bash
docker build -t user-registration-api .
```

#### 4.2 Ejecutar el contenedor Docker

```bash
docker run -p 8080:8080 user-registration-api
```

La API estará disponible en `http://localhost:8080`.

## Despliegue en Back4App

### 1. Subir el proyecto a GitHub

Sube tu código a un repositorio de GitHub para conectarlo a Back4App.

### 2. Crear una aplicación en Back4App Containers

- Crea una cuenta en [Back4App](https://www.back4app.com/).
- Crea una nueva aplicación de contenedores e importa tu repositorio de GitHub.

### 3. Configurar variables de entorno en Back4App

En la consola de Back4App, establece las siguientes variables de entorno:
- **CONNECTION_STRING**: La cadena de conexión a tu base de datos PostgreSQL.

### 4. Construir y desplegar

Back4App se encargará de construir el contenedor a partir del `Dockerfile` incluido en el proyecto y desplegarlo en su infraestructura. La aplicación estará disponible en la URL proporcionada por Back4App.

## Endpoints

La API expone los siguientes endpoints:

- **POST /api/user** - Registrar un nuevo usuario.
- **GET /api/user/{id}** - Obtener un usuario por su ID.
- **GET /api/user** - Obtener todos los usuarios.
- **PUT /api/user/{id}** - Actualizar un usuario por su ID.
- **DELETE /api/user/{id}** - Eliminar un usuario por su ID.

### Ejemplo de JSON para crear un usuario

```json
{
  "name": "Juan Pérez",
  "phone": "123456789",
  "address": "Calle 123",
  "municipalityId": 1
}
```

## Swagger

La API está documentada con **Swagger**. Una vez que la aplicación esté en ejecución, puedes acceder a la documentación de Swagger en:

```
http://localhost:8080/swagger
```

## Stored Procedures

Los procedimientos almacenados (Stored Procedures) utilizados en la base de datos son:

- **register_user**: Registrar un nuevo usuario.
- **get_user_by_id**: Obtener un usuario por su ID.
- **get_all_users**: Obtener todos los usuarios.
- **update_user**: Actualizar un usuario.
- **delete_user**: Eliminar un usuario.

### Script SQL para los procedimientos almacenados

```sql
CREATE OR REPLACE FUNCTION register_user(
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address TEXT,
    p_municipality_id INT
) RETURNS VOID AS $$
BEGIN
    INSERT INTO public."user" (name, phone, address, municipality_id)
    VALUES (p_name, p_phone, p_address, p_municipality_id);
END;
$$ LANGUAGE plpgsql;
```

## Estructura del Proyecto

```
.
├── Controllers
│   └── UserController.cs
├── Data
│   └── AppDbContext.cs
├── Models
│   └── User.cs
├── Program.cs
├── appsettings.json
├── Dockerfile
├── .dockerignore
├── .env
└── README.md
```

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir, por favor abre un **issue** o envía un **pull request** en GitHub.

## Licencia

Este proyecto está bajo la licencia MIT. Para más detalles, consulta el archivo [LICENSE](LICENSE).
```
