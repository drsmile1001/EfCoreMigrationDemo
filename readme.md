# EntityFramework core migration 示範

## 操作過程
1. 建立專案
```shell
dotnet new webapi -o EfCoreMigrationDemo
```
2. 加入 EntityFramework core 相關lib
```shell
dotnet add package Microsoft.EntityFrameworkCore.Design
# 如果是 MS SQL Server
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
# 如果是 PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
3. 加入初次的資料表定義

Person.cs
```csharp
namespace EfCoreMigrationDemo.Entities;

public class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
```

AppDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;

namespace EfCoreMigrationDemo.Entities;

public class AppDbContext : DbContext
{
    public virtual DbSet<Person> People { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("ID");

            entity.Property(e => e.Name)
                .HasComment("姓名");
        });
    }
}
```