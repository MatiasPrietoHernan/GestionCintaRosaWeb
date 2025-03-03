# Importante

- Instalar las dependencias en cada carpeta (CapaDatos, CapaLogica, GestionCintaRosaWeb) con "dotnet restore"
- una vez que cambiar la cadena conexión de la base de datos por el nombre que tengás en tu entorno en appsettings de GestionCintaRosaWeb  "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-PKV8IPB\\SQLEXPRESS;Database=CintaRosa;Integrated Security=True;TrustServerCertificate=True; Encrypt=False;"
    }, esto tengo yo, ustedes deberían en server lo que les corresponda a ustedes
- Una vez que está todo eso debemos cambiar la cadena conxión en AppDbContextFactory.cs de CapaDatos. Esta línea .UseSqlServer("Server=DESKTOP-PKV8IPB\\SQLEXPRESS;Database=CintaRosa;Trusted_Connection=True;TrustServerCertificate=True;") deben cambiar por lo que tengan ustedes.
- Después, debemos correr las migraciones de base de datos, esto eventualmente se va cambiar porque a la base de datos hay que rearmarla. Estos son los comandos:
  - Abrimos la consola de administrador de paquetes desde la pestaña Herramientos de Visual Studio y colocar este comando "Update-Database" esto va correr la base de datos de acuerdo la migraciones que tenemos quiero creer que no hace falta correr las migraciones de nuevo.
 
## Cualquier duda o consulta me pegan un tubazo.  
