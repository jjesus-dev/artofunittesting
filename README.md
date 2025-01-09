# Comandos para armar la aplicación

## Crear la solución
A) Con la carpeta creada previamente

``dotnet new sln``

B) En caso de querer generar también la carpeta

``dotnet new sln -o artofunittesting``

## Agregar proyectos

A) Aplicación de consola (dentro en la carpeta raíz)

``dotnet new console -o LogAn``

B) Aplicación de consola (fuera en la carpeta raíz)
``dotnet new console -o artofunittesting.LogAn``

Agregar el proyecto a la solución

``dotnet sln artofunittesting.sln add LogAn/LogAn.csproj``

## Agregar test (con template)

``dotnet new nunit -o LogAn.UnitTests``

## Agregar referencias

A) Una sola referencia

``dotnet add .\Namespace.App\ProyectoBase.csproj reference .\Namespace.App\ReferenciaProyecto2.csproj``

B) Varias referencias

``dotnet add Namespace.App\ProyectoBase.csproj reference Namespace.App\ReferenciaProyecto2.csproj Namespace.App\ReferenciaProyecto3.csproj``

## Correr pruebas

``dotnet test``

## Archivo gitignore

``dotnet new gitignore``
