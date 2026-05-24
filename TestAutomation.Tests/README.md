# TestAutomation — Selenium WebDriver Test Suite

Proyecto de automatización de pruebas funcionales con Selenium WebDriver, C# y NUnit, siguiendo el patrón de diseño **Page Object Pattern** para garantizar mantenibilidad, robustez y escalabilidad.

---

## 📋 Tabla de contenidos

- [Descripción general](#descripción-general)
- [Tecnologías y dependencias](#tecnologías-y-dependencias)
- [Arquitectura del proyecto](#arquitectura-del-proyecto)
- [Estructura de carpetas](#estructura-de-carpetas)
- [Configuración e instalación](#configuración-e-instalación)
- [Ejecución de pruebas](#ejecución-de-pruebas)
- [Descripción de los tests](#descripción-de-los-tests)
- [Patrones y buenas prácticas](#patrones-y-buenas-prácticas)
- [Notas importantes](#notas-importantes)

---

## Descripción general

Este proyecto implementa una suite de pruebas automatizadas sobre la aplicación de práctica [https://curso.testautomation.es](https://curso.testautomation.es), cubriendo los siguientes escenarios:

- Carga básica y lenta de páginas web
- Interacción con selectores HTML (ID, clase, CSS, XPath, relativos)
- Manejo de `iFrames`
- Verificación de catálogo de productos (frutas y vegetales)
- Funcionalidad de búsqueda
- Gestión completa del carrito de compras

---

## Tecnologías y dependencias

| Herramienta | Versión recomendada | Descripción |
|---|---|---|
| .NET / C# | 8.0+ | Lenguaje de programación |
| NUnit | 3.x | Framework de pruebas |
| NUnit3TestAdapter | 4.x | Adaptador para ejecutar tests en Visual Studio |
| Selenium WebDriver | 4.x | Automatización del navegador |
| FluentAssertions | 6.x | Escritura de aserciones en lenguaje natural |
| ChromeDriver | Última estable | Driver para Google Chrome |
| Visual Studio | 2022 | IDE principal |

> Todas las dependencias se gestionan mediante **NuGet**.

---

## Arquitectura del proyecto

El proyecto sigue la arquitectura **Page Object Pattern (POP)**, que separa la lógica de prueba de la representación de la interfaz de usuario:

```
Test (FreshMarketTests)
    └── PageObject (HomePageObject, ShoppingCartPageObject)
            └── WebElement (FruitWebElement, CartItemWebElement, SearchBarWebElement, PageBarWebElement)
                    └── Helper (FruitHelper, WaitHelper)
                            └── Model (FruitModel)
```

**Principios aplicados:**
- **Single Responsibility**: cada clase tiene una única responsabilidad.
- **DRY (Don't Repeat Yourself)**: el código común se centraliza en `SetUp`, `TearDown` y clases Helper.
- **Esperas estables**: se usa `WaitHelper` y `WebDriverWait` en lugar de `Thread.Sleep`.

---

## Estructura de carpetas

```
TestAutomation.Tests/
│
├── Frame/
│   └── FrameTests.cs               # Tests de iFrames
│
├── Inicio/
│   └── TestBasico.cs               # Tests básicos de carga de página
│
├── PageObjectPattern/
│   ├── FreshMarketTests.cs         # Suite principal de tests (frutas, búsqueda, carrito)
│   │
│   ├── Helpers/
│   │   ├── FruitHelper.cs          # Conversión entre WebElement, FruitWebElement y FruitModel
│   │   └── WaitHelper.cs           # Método de espera por condición booleana
│   │
│   ├── Models/
│   │   └── FruitModel.cs           # Modelo de datos de fruta/vegetal
│   │
│   └── PageObject/
│       ├── HomePage/
│       │   ├── HomePageObject.cs         # Página principal de la tienda
│       │   ├── FruitWebElement.cs        # Elemento web individual de fruta
│       │   ├── PageBarWebElement.cs      # Barra de navegación entre páginas
│       │   └── SearchBarWebElement.cs    # Barra de búsqueda
│       │
│       └── ShoppingCart/
│           ├── ShoppingCartPageObject.cs # Carrito de compras
│           └── CartItemWebElement.cs     # Elemento individual del carrito
│
└── Selectores/
    └── SelectoresTests.cs          # Tests de tipos de selectores CSS/XPath/ID
```

---

## Configuración e instalación

### 1. Requisitos previos

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/downloads/) con carga de trabajo **.NET desktop development**
- [Google Chrome](https://www.google.com/chrome/) (versión actualizada)
- ChromeDriver compatible con tu versión de Chrome (se gestiona automáticamente vía NuGet con `Selenium.WebDriver.ChromeDriver`)

### 2. Clonar el repositorio

```bash
git clone <url-del-repositorio>
cd TestAutomation
```

### 3. Restaurar paquetes NuGet

Abre la solución en Visual Studio y restaura los paquetes:

```
Solución → Click derecho → Restaurar paquetes NuGet
```

O desde la terminal:

```bash
dotnet restore
```

### 4. Compilar la solución

```bash
dotnet build
```

---

## Ejecución de pruebas

### Desde Visual Studio

1. Abre el **Explorador de pruebas** (`Ver → Explorador de pruebas`)
2. Selecciona los tests a ejecutar
3. Click en **Ejecutar** o **Depurar**

### Desde la terminal

Ejecutar todos los tests:

```bash
dotnet test
```

Ejecutar un test específico:

```bash
dotnet test --filter "FullyQualifiedName~ShoppingCartTest"
```

Ejecutar con salida detallada:

```bash
dotnet test --logger "console;verbosity=detailed"
```

---

## Descripción de los tests

### `TestBasico.cs` — Pruebas básicas de carga

| Test | Descripción |
|---|---|
| `TestBasicWebPage` | Navega a la página principal, hace clic en "Normal load website" y verifica el título |
| `TestSlowLoadWebPage` | Verifica la carga lenta con espera explícita por `id="title"` |
| `TestSlowLoadTextWebPage` | Verifica texto de carga lenta con espera explícita |

### `SelectoresTests.cs` — Tipos de selectores

| Test | Descripción |
|---|---|
| `GetEachOfTheElements` | Demuestra el uso de selectores por ID, ClassName, Name, CSS, XPath, relativos y listas |

### `FrameTests.cs` — Manejo de iFrames

| Test | Descripción |
|---|---|
| `FrameTest` | Navega entre dos iFrames y extrae el texto de cada uno usando `SwitchTo().Frame()` |

### `FreshMarketTests.cs` — Tienda de frutas y vegetales

| Test | Descripción |
|---|---|
| `VerifyThatFruitsAreCorrectlyDisplayed` | Recorre las 3 páginas del catálogo y verifica que los 28 productos coincidan con los datos esperados |
| `SearchTests` | Prueba la barra de búsqueda con los términos `"app"`, `""` (vacío) y `"ape"` usando clic y tecla Enter |
| `ShoppingCartTest` | Flujo completo del carrito: añadir productos, verificar ícono, abrir carrito, validar ítems y totales, eliminar producto, actualizar cantidades y cerrar |

---

## Patrones y buenas prácticas

### SetUp y TearDown

Cada clase de test inicializa y libera el driver correctamente:

```csharp
[SetUp]
public void SetUp()
{
    driver = new ChromeDriver();
    driver.Manage().Window.Maximize();
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
    driver.Url = "https://...";
}

[TearDown]
public void TearDownTest()
{
    driver.Quit();
}
```

### Esperas estables (sin Thread.Sleep)

Se utiliza `WaitHelper.WaitForCondition()` y `WebDriverWait` para esperar condiciones sin pausas fijas:

```csharp
WaitHelper.WaitForCondition(() => int.Parse(ShoppingCartIcon.Text).Equals(number));
```

### Lambda para elementos frescos del DOM

Para evitar `StaleElementReferenceException` tras cambios en el DOM:

```csharp
var item = () => cart.CartItemWebElements;  // siempre trae el estado actual
item().ElementAt(i).GetText();
```

### Separación de responsabilidades

- Los **Page Objects** encapsulan los selectores y acciones de cada página.
- Los **WebElements** representan componentes complejos (fruta, ítem de carrito).
- Los **Helpers** contienen lógica reutilizable (parseo, esperas).
- Los **Models** son objetos de datos puros sin dependencia de Selenium.

---

## Notas importantes

- ⚠️ `Thread.Sleep()` está **prohibido** en este proyecto. Usar siempre esperas basadas en condición.
- ⚠️ Los selectores deben coincidir **exactamente** con los atributos HTML de la página bajo prueba, incluyendo guiones (ej. `cart-icon`, `search-button`).
- ⚠️ Al añadir frutas al carrito, siempre asignar `model.Quantity` después de `FruitHelper.Parse()`, ya que el constructor de `FruitModel` no incluye ese parámetro.
- El proyecto está configurado para ejecutarse sobre **Google Chrome**. Para otros navegadores se debe instanciar el driver correspondiente.

---

## Aplicación bajo prueba

> [https://curso.testautomation.es](https://curso.testautomation.es)

Página de práctica diseñada específicamente para aprender automatización con Selenium, con escenarios de carga normal, carga lenta, selectores, iFrames y una tienda de frutas y vegetales.

---

*Proyecto desarrollado como laboratorio de aprendizaje de Selenium WebDriver con C# y el patrón Page Object.*
