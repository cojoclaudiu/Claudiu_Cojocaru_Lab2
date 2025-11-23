# Claudiu_Cojocaru_Lab2

- Pentru ca nu mai exista suport pentru Visual Studio pentru macOS a trebuit sa folosesc o masina virtuala pentru a rula Windows.
- Pentru ca folosesc Windows 11 ARM in VM Warefusion (pentru Apple Silicone) am avut o problema in a rula SQL Server si a trebuit sa folosesc SQLite.

## DEMO

https://github.com/user-attachments/assets/9cb79dd4-6c91-49db-b6ef-8594ed5b8cb3

https://github.com/user-attachments/assets/1b252c57-ed31-47eb-bc50-5dcb230895cd

https://github.com/user-attachments/assets/4eb054e9-ea99-49bc-bb5f-a50a3889f48d

<img width="1265" height="676" alt="Screenshot 2025-11-09 at 12 42 21" src="https://github.com/user-attachments/assets/01568858-9366-48f8-afbf-a05e2a717de2" />

# 📌 Instrucțiuni de Dezvoltare

## 🚀 Crearea unei Migrații Noi

> Rulați aceste comenzi **din proiectul care conține DbContext-ul**.

Creați o migrație:

```sh
dotnet ef migrations add NumeMigratie
```

Exemplu:

```sh
dotnet ef migrations add InitialCreate
```

Creați o migrație într-un folder specific:

```sh
dotnet ef migrations add AddBooks --output-dir Data/Migrations
```

Dacă DbContext-ul se află în alt proiect:

```sh
dotnet ef migrations add NumeMigratie --project ProiectDate --startup-project ProiectWeb
```

---

## 🛠 Actualizarea Bazei de Date

Aplică ultima migrație:

```sh
dotnet ef database update
```

Aplică o migrație specifică:

```sh
dotnet ef database update NumeMigratie
```

---

## 🧩 Crearea de Razor Pages (CRUD)
```sh
dotnet aspnet-codegenerator razorpage \
  -m Book \
  -dc Claudiu_Cojocaru_Lab2Context \
  -udl \
  -outDir Pages/Books
```

## Descrierea flag-urilor pentru `dotnet aspnet-codegenerator razorpage`

### `-m <ModelName>`
Specifică numele clasei modelului pentru care se vor genera paginile Razor.
Exemplu: `-m Member`

### `-dc <DbContext>`
Definește numele clasei DbContext folosit pentru generarea codului.
Exemplu: `-dc Claudiu_Cojocaru_Lab2Context`

### `-udl`
Folosește layout-ul implicit `_Layout.cshtml` din proiect.
Acronim: **Use Default Layout**

### `-outDir <folder>`
Setează directorul în care vor fi generate fișierele Razor.
Exemplu: `-outDir Pages/Members`


## ▶️ Build & Rulare Server Dev

Build proiect:

```sh
dotnet build
```

Rulare proiect:

```sh
dotnet run
```

Rulare cu auto-reload (recomandat):

```sh
dotnet watch run
```
