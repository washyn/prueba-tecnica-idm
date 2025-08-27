## Prueba Técnica Backend Developer – .NET 8 Web API

### Contexto

La marca KFC desea ofrecer sus productos a través de distintos canales de venta: RAPPI,
DIDI, PEYA y WEB.
Un producto puede tener distintos precios para los canales debido a estrategias
comerciales o promociones.
La API debe permitir mantener los productos y sus precios por canal de venta.

### Objetivo

Construir una API REST en ASP.NET Core 8, que permita gestionar:
• Productos
• Canales de venta
• Precios por canal

### Requisitos funcionales

1. Entidades base
   Según tu análisis define las entidades y sus relaciones entre sí
   Endpoints requeridos

#### CRUD de productos

• GET /api/products
• POST /api/products
• PUT /api/products/{id}
• DELETE /api/products/{id}

#### Precios por canal

• GET /api/prices?productId={id}
• POST /api/prices → Crear nuevo precio (debe validar que no exista ya un activo)
• PUT /api/prices/{id}
• DELETE /api/prices/{id}

#### Canales (mockeados o precargados en memoria)

• GET /api/canales

#### Requisitos técnicos

#### Persistencia

• Implementación con EF Core Code First
• Soporte para SQLite o InMemory, configurable

#### Arquitectura

• Aplicar Arquitectura Limpia o por capas
• Separación clara:
o Domain: entidades, interfaces
o Application: casos de uso, servicios
o Infrastructure: repositorios EF Core
o API: controladores, mapeos, Swagger

#### Testing

• Al menos una prueba de negocio que valide que no se pueden crear dos precios
activos para el mismo producto y canal
• Uso de xUnit + Moq (o similar)

#### Buenas prácticas

• Verbos HTTP correctos
• Código limpio, DTOs separados
• Validaciones con FluentValidation
• Manejo de errores global (middleware si aplica)
• Uso de ILogger
• Inyección de dependencias
• Aplicación de principios SOLID
• Patrones: Repository y Service Layer (mínimo)

#### Tiempo Estimado

• Máximo: 8 horas
• Cumplido el tiempo máximo permitido, enviar el entregable hasta donde se haya
avanzado

#### Entregables

1. Código fuente en un repositorio o .zip
2. README con:
   o Justificación del modelo de dominio
   o Arquitectura aplicada
   o Qué principios SOLID se aplicaron
   o Patrones utilizados
   o Cómo correr el proyecto (SQLite/InMemory)
   o Cómo ejecutar pruebas unitarias
   o Qué se podría mejorar si tuviera más tiempo.
