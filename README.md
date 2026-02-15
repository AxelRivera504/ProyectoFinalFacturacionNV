# Facturación Proyecto Final - Arquitectura Base

## 📌 Descripción

Este proyecto corresponde a la primera etapa del desarrollo de una API de facturación utilizando arquitectura por capas (Clean Architecture).

En esta clase se trabajó exclusivamente en:

- Definición de entidades del dominio
- Implementación de BaseEntity con auditoría
- Estructura de solución por proyectos
- Configuración inicial de Infrastructure

No se desarrollaron endpoints todavía. El objetivo fue sentar las bases arquitectónicas del sistema.

---

## 🏗 Arquitectura del Proyecto

La solución está dividida en los siguientes proyectos:

### 🔹 Facturacion.WebApi
- Punto de entrada del sistema.
- Contendrá Controllers y configuración HTTP.
- No debe contener lógica de negocio.

### 🔹 Facturacion.Application
- Contendrá casos de uso.
- Servicios de aplicación.
- Validaciones.
- Orquestación del flujo del sistema.

### 🔹 Facturacion.Domain
- Núcleo del sistema.
- Entidades.
- Reglas de negocio.
- BaseEntity con auditoría.
- No depende de ningún otro proyecto.

### 🔹 Facturacion.Infrastructure
- Implementación técnica.
- DbContext.
- Configuración de Entity Framework.
- Acceso a base de datos.

### 🔹 Shared
- DTOs.
- ApiResponse.
- Clases comunes compartidas.
- Modelos de request/response.

---

## 🧠 Principios aplicados

- Separación de responsabilidades.
- Arquitectura limpia.
- Independencia del dominio.
- Preparado para escalabilidad.
- Preparado para despliegue en Azure.
- Preparado para migraciones Code First.

---

## 🗂 Estructura actual

