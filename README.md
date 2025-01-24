Aby skompilować i uruchomić aplikację:
1. Zainstaluj .NET SDK 8.0
2. W wierszu poleceń w katalogu z solucją odpal polecenie `dotnet publish --configuration Release`
3. Otwórz plik `Src\HardkorowyKodsu.Backend\bin\Release\net8.0\appsettings.json` i w polu `ConnectionStrings`->`Default` wprowadź connection string do swojej bazy
4. Odpal backend: `Src\HardkorowyKodsu.Backend\bin\Release\net8.0\HardkorowyKodsu.Backend.exe`
5. Odpal aplikację kliencką: `Src\HardkorowyKodsu\bin\Release\net8.0-windows\HardkorowyKodsu.exe`
