# KFC API - Gestión de Productos y Precios por Canal

Este proyecto es una API REST hecha con ASP.NET Core 8 que nos permite gestionar los productos de KFC, sus canales de venta y los precios en cada canal.

## ¿Por qué este Modelo de Dominio?

Se ha diseñado nuestro el modelo de dominio pensando en lo siguiente:

- **Producto**: Representa los productos de KFC con sus datos básicos: Id, Name y Sku.
- **Canal**: Son nuestras vías de venta (RAPPI, DIDI, PEYA, WEB). Cada uno tiene su código, nombre y estado activo/inactivo.
- **Precio**: Es el puente que conecta Productos y Canales, añadiendo cuánto cuesta y en qué moneda.

Este enfoque refleja la realidad del negocio: un mismo producto puede costar diferente según dónde lo compres, permitiendo hacer ofertas y promociones específicas para cada canal.

## ¿Cómo está construido?

Se ha usado una arquitectura limpia (Clean Architecture) que separa todo en capas bien organizadas:

1. **Capa de Dominio** (`Domain`) - El core del sistema:

   - Aquí estan nuestras entidades (Product, Channel)
   - Las interfaces de repositorios (IProductRepository)

2. **Capa de Aplicación** (`Application`):

   - Los servicios que hacen el trabajo duro (ProductsAppService)
   - DTOs para mover datos de un lado a otro
   - Validaciones con **FluentValidation** para que nadie meta datos raros
   - Mapeos automáticos con **AutoMapper**

3. **Capa de Infraestructura** (`Infrastructure`) - Infraestructura:

   - Repositorios que hablan con la base de datos usando Entity Framework Core
   - Configuración de SQLite para guardar todo
   - Migraciones para evolucionar la base de datos

4. **Capa de API** (`Api`) - La presentacion:
   - Controladores REST que exponen todo
   - Swagger para que probar la API
   - Middleware para capturar errores y que nada se rompa
   - Toda la configuración necesaria

## Principios SOLID:

1. **Principio de Responsabilidad Única (SRP)** - Una tarea por clase:

   - Cada clase hace solo UNA cosa (como ProductsAppService que solo se ocupa de la lógica de productos)
   - Separamos todo

2. **Principio de Abierto/Cerrado (OCP)** - Extender sí, modificar no:

   - Usamos interfaces y clases abstractas para poder añadir funcionalidades sin tocar el código existente
   - Nuestros repositorios son como bases que puedes ampliar sin romper nada

3. **Principio de Sustitución de Liskov (LSP)** :

   - La herencia la usamos con cabeza en controladores y servicios
   - Los servicios heredan de CrudAppService y se comportan como deberían(para el ejemplo solicitado de crud de productos)

4. **Principio de Segregación de Interfaces (ISP)** - Interfaces a medida

   - Creamos interfaces específicas como IProductRepository en vez de interfaces gigantes que hacen de todo
   - Cada servicio tiene su contrato bien definido (IProductsAppService)

5. **Principio de Inversión de Dependencias (DIP)** - Depender de abstracciones, no de detalles de implemetacion (para poder realizar tests unitarios e integrales):
   - Inyectamos dependencias en los constructores
   - Trabajamos con interfaces en vez de clases concretas
   - Configuramos todos los servicios de forma centralizada en los módulos

## Patrones:

1. **Patrón Repositorio** - El almacén de datos :

   - Usamos IProductRepository como una puerta de acceso a los datos sin preocuparnos por los detalles
   - La implementación real está en ProductRepository con EF Core haciendo el trabajo sucio que se puede cambiar por otro orm de acceso a datos o SPs segun sea necesario.

2. **Patrón Servicio**:

   - Servicios como ProductsAppService que contienen toda la lógica del negocio
   - Mantienen los controladores limpios y enfocados en la comunicación

3. **Patrón DTO (Data Transfer Object)**:

   - Objetos como ProductDto y PriceDto que llevan datos entre capas
   - Evitan exponer las entidades del dominio al exterior

4. **Patrón Unidad de Trabajo (Unit of Work)** - Para asegurar las transacciones con ef core:

   - Implementado con app.UseUnitOfWork()
   - Garantiza que todas las operaciones de base de datos se completen o fallen juntas

5. **Patrón Módulo** - Los bloques de construcción:

   - Organizamos todo en módulos cohesivos (ApiModule, ApplicationModule...)
   - Cada módulo tiene su propia responsabilidad y configuración

6. **Patrón Fábrica** - Para crear objetos:

   - EntityFrameworkCoreDbContextFactory crea contextos de base de datos cuando los necesitamos en la migracion y creacion de base de datos
   - Centraliza la lógica de creación de objetos complejos

7. **Patrón Validador** - Para asegurar que los datos sean correctos:
   - Validadores con **FluentValidation** que aseguran que los datos sean correctos
   - Código de validación limpio, legible y separado de la lógica de negocio

## Para ejecutar el proyecto:

### Lo que se necesita tener instalado

- .NET 8 SDK
- Un editor de código (Visual Studio, VS Code, Rider...)

### Pasos para ejecutar

1. Restaurar paquetes NuGet:

   ```
   dotnet restore
   ```

2. Ejecutar la aplicación:

   ```
   cd src/Api
   dotnet run
   ```

3. Acceder a Swagger para probar la API:
   ```
   http://localhost:5004/swagger
   ```

### Sobre la base de datos

Usamos SQLite porque es ligero y no requiere instalacion como se solicito en la descripcion de la prueba. La configuración está en `src/Api/appsettings.json`, se puede cambiar por sqlite en memoria para los tests integrales(en infraestructura):

```json
{
  "ConnectionStrings": {
    "Default": "Data Source=.KFC.db;"
  }
}
```

## Para ejecutar tests

1. En la carpeta de pruebas:

   ```
   cd tests
   ```

2. Ejecutar las pruebas:

   ```
   dotnet test
   ```

## Si tuviéra mas tiempo...

1. **Completar los Precios**:

   - Terminar el CRUD completo de precios con todas sus validaciones
   - Añadir reglas de negocio más específicas

2. **Más pruebas** :

   - Pruebas de integración para ver cómo funciona todo junto
   - Cobertura de todos los casos de uso
   - Probar todas las validaciones

3. **Seguridad** :

   - Implementar JWT o OAuth para que no entre cualquiera
   - Añadir roles y permisos

4. **Documentación** :

   - Swagger con ejemplos que realmente ayuden
   - Guías de uso

5. **Velocidad** :

   - Caché
   - Consultas a la base de datos optimizadas

6. **Versionado para el futuro**:

   - Poder evolucionar la API sin romper aplicaciones existentes

7. **Logging avanzado**:

   - Registros detallados de todo lo que pasa
   - Integración con herramientas de monitoreo

8. **Healthchecks para saber si todo va bien** :

   - Endpoints que nos digan si el sistema está bien o esta fallando

9. **Dockerización para desplegar** :
   - Contenedores Docker para que funcione igual en todas partes
