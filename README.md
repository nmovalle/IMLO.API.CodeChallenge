# IMLO.API.CodeChallenge

Bienvenido a **IMLO.API.CodeChallenge**, una API desarrollada en .NET 8 que implementa buenas prácticas de diseño y arquitectura para asegurar una solución robusta, escalable y fácil de mantener.

---

## 🚀 Características principales

### 1. **.NET 8**
Desarrollada en la última versión de .NET para aprovechar su rendimiento, nuevas características y soporte a largo plazo.

### 2. **Patrón de diseño: Repositorios**
Implementa el **Patrón de Repositorios**, permitiendo un acceso más estructurado a la capa de datos y reduciendo la dependencia directa del ORM.

### 3. **Unit of Work**
Integra el patrón **Unit of Work** para gestionar transacciones de forma eficiente y asegurar la consistencia de los datos en operaciones complejas.

### 4. **Entity Framework Core**
Utiliza **Entity Framework Core** como ORM, lo que permite trabajar con modelos de datos de manera fluida y simplificada, aprovechando sus características avanzadas como LINQ y migraciones.

### 5. **Ejecución de Stored Procedures**
Soporte nativo para la **ejecución de Stored Procedures**, permitiendo integraciones directas con consultas optimizadas en bases de datos relacionales.

---

## 🛠️ Requisitos previos

Para ejecutar este proyecto localmente, necesitarás:

- **.NET SDK 8.0 o superior**  
- **SQL Server** (u otro sistema compatible con Entity Framework Core)  
- **Visual Studio 2022** o **VS Code** con extensiones de .NET  

---

## ⚙️ Configuración

1. **Clona este repositorio**:
   ```bash
   git clone https://github.com/nmovalle/IMLO.API.CodeChallenge.git
   cd IMLO.API.CodeChallenge
