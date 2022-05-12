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
public class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
```

AppDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;

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
4. 加入資料庫遷移
```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }
    //省略
}
```

Program.cs
```csharp
//省略
//簡單註冊DbContext
builder.Services.AddDbContext<AppDbContext>(b => b.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
//繞過需要 ConnectionString
builder.Services.AddDbContext<AppDbContext>(b =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionString))
        b.UseSqlServer();
    else
        b.UseSqlServer(connectionString);
});
//省略
```
[更正規做法參考](https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory)

appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "<按狀況填寫>"
  }
}
```

```shell
#dotnet ef migrations add <本次異動名稱>
dotnet ef migrations add Init
dotnet ef migrations script -o oupput.sql
```
