# Instalar Entity Framework Core Tools
dotnet tool install --global dotnet-ef

# Comando Scafold para modelar la base de datos
dotnet ef dbcontext scaffold "Server=localhost;Database=FarmaciaTalentoTech;User Id=sa;Password=admin;Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f