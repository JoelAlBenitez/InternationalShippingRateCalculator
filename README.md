🌍 International Shipping Rate Calculator

Sistema avanzado para el cálculo automatizado de tarifas de envío internacionales, diseñado bajo principios de Clean Architecture y Domain-Driven Design (DDD) para garantizar escalabilidad, mantenibilidad y resiliencia en entornos de alto rendimiento.

🚀 Descripción del Proyecto

El sistema surge de la necesidad de una empresa de comercio electrónico de automatizar el cálculo de costos de envío internacionales. Permite a los clientes ingresar el peso de sus paquetes y seleccionar un destino, obteniendo de forma instantánea el costo basado en reglas de negocio específicas para cada región.

🛠 Reglas de Negocio Aplicadas

El cálculo se realiza mediante un motor de reglas desacoplado que aplica las siguientes tarifas:

🇮🇳 India: Tarifa = Peso × 5 USD.

🇺🇸 Estados Unidos (US): Tarifa = Peso × 8 USD.

🇬🇧 Reino Unido (UK): Tarifa = Peso × 10 USD.

🏗 Arquitectura del Sistema

La solución implementa una Arquitectura en Capas con Inversión de Dependencia (DI) para evitar el acoplamiento y facilitar el mantenimiento.

📁 Distribución de Capas

Capa de Dominio (Domain):

Contiene las entidades POCO (Country, Shipment).

Implementa los Validadores de Negocio y las interfaces de reglas.

Define los Modelos de Lectura (Read Models) y códigos de error comunes.

Capa de Aplicación (Application):

Contiene las Interfaces de Repositorio (Contratos).

Implementa el TariffService para la orquestación de la lógica.

Gestiona los Validadores de Input y la transformación de datos.

Capa de Infraestructura (Infrastructure):

Implementa la persistencia mediante Entity Framework Core.

Contiene el ShippingDbContext y la implementación del repositorio.

Configura la conexión a SQL Server mediante secretos de usuario.

Capa de Presentación (Presentation):

Implementada como una Minimal API (o Razor Pages según configuración) para máxima eficiencia.

Diseño basado en las 10 Heurísticas de Nielsen para asegurar una excelente UI/UX.

📸 Evidencias de Diseño y Funcionamiento

A continuación se presentan las capturas de pantalla que validan la arquitectura y el flujo operativo del sistema (ubicadas en /Screenshots):

Vista General del Sistema

Arquitectura de Capas

Diagrama de Componentes

Interfaz de Usuario

Validación de Reglas

Resultados del Cálculo


⚙️ Configuración y Despliegue

🗄️ Base de Datos

El sistema utiliza SQL Server con el nombre InternationalShippingRateCalculator.

El script de creación se encuentra en la carpeta: ./database/script.sql.

Servidor recomendado: (localdb)\MSSQLLocalDB.

🔐 Seguridad y Conexión

La cadena de conexión no está en el código. Se debe configurar vía User-Secrets o en el appsettings.json local:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=InternationalShippingRateCalculator;Trusted_Connection=True;"
}


🎯 Objetivos de la Solución

Desacoplamiento: Las capas se comunican exclusivamente mediante abstracciones.

POCO: Entidades de dominio libres de dependencias de persistencia.

Resiliencia: Manejo robusto de excepciones (try-catch) para evitar caídas del sistema.

Mantenibilidad: Inversión de Control (IoC) centralizada para la carga de dependencias.

Desarrollado por: Joel Alberto Benitez Varela (2025-1049)