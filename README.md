# Veterinary Clinic — xUnit Test Suite

## A C# xUnit testing project that validates the core functionality of the [Veterinary Management Console App](https://github.com/Henri-Claassen/Vet_Clinic_Project). This project covers unit tests for user authentication, animal/owner viewing, and the main menu controller.

---

## 🧪 Test Coverage Overview

### 🔐 UserLoginTest
Tests the `displayLogin()` method which authenticates users against a stored credential set (default: `Test` / `123`).

| Test | Input | Expected |
|------|-------|----------|
| `Test1` | Valid username & password | `true` |
| `Test2` | Invalid username, valid password | `true` *(intentional failure case)* |
| `Test3` | Valid username, invalid password | `true` *(intentional failure case)* |
| `Test4` | Invalid username & password | `true` *(intentional failure case)* |

> ⚠️ Tests 2, 3, and 4 are currently written to expose authentication edge cases — they assert `true` on invalid credentials, which may indicate intended failure scenarios for review.

---

### 🐾 ViewAnimalsTest
Tests the `ViewAnimals()` method which displays animals and owners based on an enum-driven choice (`Display_Animal` = 0, `Display_Owner` = 1).

| Test | Scenario | Expected Result |
|------|----------|-----------------|
| `TestViewInvalidInput` | Input value out of enum range (2) | `"Failed"` |
| `TestViewEmptyOwner` | Empty owner list, display owner | `"No Owner"` |
| `TestViewOwner` | Owner exists in list | `"Owner"` |
| `TestViewEmptyAnimal` | Empty animal list, display animal | `"No Animal"` |
| `TestViewMammals` | Mammal in animal list | `"Mammals"` |
| `TestViewBirds` | Bird in animal list | `"Birds"` |
| `TestViewReptile` | Reptile in animal list | `"Reptiles"` |
| `TestViewWaterAnimal` | Water animal in animal list | `"Water"` |

The following animal class hierarchy is defined locally within the test project to mirror the main application's OOP structure:


Owner
  └── Animal
        ├── Mammals   (furType, legCount)
        ├── Birds     (wingSpan)
        ├── Reptiles  (scaleType)
        └── WaterAnimals (gilCount, finCount)

---

### 🗂️ MenuControllerTests
Tests the `MenuController.Handle()` method using fake/mock implementations (`FakeActions`, `FakeConsole`, `FakeUserLogin`) to isolate behaviour without depending on the real console or application logic.

| Test | Menu Option | Assertions |
|------|-------------|------------|
| `AddAnimal_ClearsConsole_SetsCursorVisible_InvokesAddAnimal_Continues` | `Add_Animal` | Console cleared, cursor visible, `AddAnimal` called, returns `true` |
| `NonLoginNonExitOptions_ClearConsole_InvokeCorrectAction_Continue` *(Theory)* | `View_All_Animals`, `Search_Animal`, `View_Med_Inventory`, `Calc_Med_Dosage`, `Add_Employee`, `Manage_Appointments`, `Calc_Emp_Salary` | Console cleared, correct action invoked, returns `true` |
| `ExitProgram_DoesNotClearConsole_CallsExit_ReturnsFalse` | `Exit_Program` | Console NOT cleared, `ExitProgram` called, returns `false` |

Interfaces used for test isolation:

  `IMenuActions` — abstracts all menu action methods
  `IConsoleService` — abstracts `Console.Clear()` and `CursorVisible`
  `IUserLogin` — abstracts the login display method

---

## 📚 Technologies Used

C#
  .NET (xUnit Test Framework)
  xUnit `[Fact]` and `[Theory]` attributes
  Interface-based mocking (no third-party mock library)
  Object-Oriented Programming (OOP) — Inheritance & Polymorphism

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed
- Visual Studio or any compatible IDE (e.g. JetBrains Rider, VS Code)
- The main [Veterinary Management Console App](https://github.com/Henri-Claassen/Vet_Clinic_Project) project (referenced by this test suite)

### Installation

1. Clone this repository using github desktop or bash:
   bash:  git clone https://github.com/Henri-Claassen/Software-Testing

2. Open the solution in Visual Studio and ensure the main `Vet_Clinic_Project` is also available and referenced.

3. Build the solution to restore dependencies.

4. Run all tests via the Test Explorer in Visual Studio, or using the CLI.


## 🛠️ Project Structure

SWT281_XUnitTesting/
  └── UnitTest1.cs
        ├── UserLoginTest          # Login authentication tests
        ├── Owner / Animal / ...   # Local class definitions mirroring the main project
        ├── ViewAnimalsTest        # Animal & owner list display tests
        ├── MenuController         # Menu routing logic
        ├── Fake implementations   # FakeConsole, FakeActions, FakeUserLogin
        └── MenuControllerTests    # Menu controller unit tests

---

## ⚠️ Important Notes

This project is for **educational and testing purposes**, tied to the Veterinary Management Console App.
The fake/stub classes (`FakeConsole`, `FakeActions`, `FakeUserLogin`) are scoped to file-level (`file class`) and are not accessible outside `UnitTest1.cs`.
Some login tests (`Test2`, `Test3`, `Test4`) assert `true` on invalid credentials — these may be intentional cases to highlight missing validation or areas for future improvement.
