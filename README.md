# 🌍 International Shipping Rate Calculator

![.NET](https://img.shields.io/badge/.NET-9.0-purple?logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-Clean_N--Layer-blue)
![SOLID](https://img.shields.io/badge/SOLID-Strict_Compliance-green)
![Design](https://img.shields.io/badge/Pattern-Domain--Driven_Design-orange)

> **Comprehensive solution for logistics automation.** This system allows e-commerce companies to calculate international shipping rates accurately, resiliently, and scalably..

---

## 📖 Table of Contents
* [Problem Statement](#-problem-statement)
* [Solution Benefits](#-solution-benefits)
* [Business Rules](#-business-rules)
* [System Architecture](#-system-architecture)
* [Operational Flow](#-operational-flow)
* [Installation and Implementation](#-installation-and-implementation)

---

## 🎯 Problem Statement
Currently, many e-commerce businesses lack an automated system for processing shipping rates. Manual calculations present the following shortcomings:
* **Inconsistency:** Variation in charged amounts due to human error.

* **Low Efficiency:** Difficulty in providing customers with immediate shipping costs.

* **Lack of Scalability:** Problems integrating new destinations or quickly modifying rates.

---

## 🚀 Solution Benefits
By implementing this module, the company gains strategic competitive advantages[cite: 141]:

| Benefit | Impact | Description |

:--- |:---: |:--- |

**Automation** | ⚡ | Instant calculation of shipping costs without manual intervention. |

**User Experience** | 😊 | The customer can see if they have the necessary funds before making a purchase. |

**Operational Efficiency** | 📉 | Significant reduction in order processing time. |

**Maintainability** | 🛠️ | Architecture that allows for easy modification of amounts or addition of countries. |

---

## 🧠 Business Rules
The system uses a rules engine based on the selected destination country. The general formula is:
`Rate = Package Weight × Region Factor`.

| Country | Cost Factor | Principle Applied |

| :--- | :--- | :--- |

**🇮🇳 India** | $5 USD | Open/Closed Principle |

**🇺🇸 United States** | $8 USD | Open/Closed Principle |

**🇬🇧 United Kingdom** | $10 USD | Open/Closed Principle |

---

## 🏗 System Architecture
Designed using the Layered Architecture and DDD patterns, ensuring the development team can understand and scale each component.

### 📂 Project Layers
1. **Presentation (Web UI):** Developed in Razor Pages. Contains the input capture and validation form.

2. **Application (Business Logic):** Orchestrated using the `TariffService` to process the client request.

3. **Domain:** System core. Contains the entities (`Shipment`, `Country`) and the core calculation logic (`TariffCalculator`).

4. **Infrastructure:** Persistence management with **SQL Server** and the Repository pattern (`CountryRepository`).

---

## 🔄 Operational Flow
According to the **Solution Design Diagram**[cite: 181]:

1. **Input:** The user accesses the portal and enters the weight and destination.

2. **Processing:** The system validates the data and applies the corresponding rule (`x5`, `x8`, or `x10`).

3. **Output:** The result is generated, and the final cost is displayed to the user.

---

## 📸 System Evidence

### 🖥️ User Interface
![UI](Screenshots/UIFirstSystem.png)
*User-friendly form for data entry (Weight and Destination).*

### 💰 Calculation Result
![Result](Screenshots/ExampleCalculeResult.png)
*Clear display of the automatically calculated final cost.*

---

## ⚙️ Instalación y Ejecución

### 🔧 Requisitos Previos
* .NET 6 o superior.
* SQL Server/LocalDB.
* Visual Studio 2022 o Código VS.

### 📥 Pasos para Ejecutar
1. **Repositorio Clonar:**
   ```bash
   git clone [https://github.com/tu-usuario/InternationalShippingRateCalculator.git](https://github.com/tu-usuario/InternationalShippingRateCalculator.git)

2. **Configure Database:**
    ```bash
    Ejecutar el script ubicado en /database/script.sql para crear las tablas y cargar las tarifas iniciales.

3. **Connection:**
   ```bash
   Asegúrate de que el appsettings.json apunte a tu servidor local:
   "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ShippingDB;Trusted_Connection=True;"
   
4. Run
-  ```bash
   d0otnet run

- > [!NOTE]
This project is for academic use, developed by `Joel Alberto Benitez Varela` belonging to the `Technological Institute of the Americas` of the `Dominican Republic`.
