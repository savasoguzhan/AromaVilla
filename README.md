AromaVilla

A sample N-layered .Net Core Project Demonstrating Clean Architecture and the Generic Repository Pattern.

Packages 

```
Install-Package Ardalis.Specification -v 6.1.0
```
Ingrastructure
```
Install-Package Microsoft.EntityFrameworkCore -v 6.0.15
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.15
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 6.0.8
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 6.0.15
Install-Package Microsoft.EntityFrameworkCore.Design -v 6.0.15

```
Web
````
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.15
`````

Migration
 running the following commands . make sure that Web is set as startup project. run the following commands on the project "Infrastructure"

 Infrastructure
 `````
 Add-Migration InitialCreate -context ShopContext -OutputDir Data/Migrations
 Update-Database -context ShopContext


  Add-Migration InitialIdentity -context AppIdentityDbContext -OutputDir Identity/Migrations
 Update-Database -context AppIdentityDbContext
 `````