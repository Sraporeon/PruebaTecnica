# prueba Sistema de Gestión de Contribuyentes y Comprobantes


##  Tecnologías Utilizadas
* **Backend**: .NET 8, Entity Framework Core, SQL Server.
* **Frontend**: React 18, Vite, Axios, Bootstrap.
* **Base de Datos**: SQL Server con relaciones entre Contribuyentes y Comprobantes.

##  Instrucciones de Configuración

### 1. Base de Datos (SQL Server)
1. Configure su cadena de conexión en el archivo `appsettings.json` del proyecto API.
2. Ejecute las migraciones para crear las tablas:
   ```bash
   Update-Database
3. (Opcional) Inserte datos de prueba en SSMS para ver resultados inmediatos.

### 2. Backend (.NET API)
Abra la solución en Visual Studio.

Ejecute el proyecto (F5). La API estará disponible en https://localhost:7269.

Verifique los endpoints mediante Swagger.

### 3. Frontend (React)
Navegue a la carpeta del frontend en la terminal.

Instale las dependencias: npm install 

Inicie el servidor de desarrollo: npm run dev

El API tiene habilitada una política de CORS para permitir peticiones desde el origen del frontend(di muchas vueltas aqui), asegurando que el intercambio de datos no sea bloqueado por el navegador. (spoiler: me lo bloqueo muchas veces. Pero resolvi)


![alt text](image.png) - Api activo


Agregue la API dentro de la carpeta, esta debe ejecutarse en vs.NET por lo que habria que copiarlo o moverlo de origen que conincida con VS y la plantilla ASP.NET Core Web API (acepto criticas T_T)

asegurense de tener dentro del proyecto:

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Design


Eso seria todo. La mas tedioso en este prueba fueron las primeras travas tecnicas por detalles menores. Espero que les sea de su agrado.

