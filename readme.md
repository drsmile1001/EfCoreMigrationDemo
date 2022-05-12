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