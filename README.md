# Invoice Backend

## Technologies
- ASP.NET Core 7
- Entity Framework Core 7
- Repository Design Pattern
- PostgreSQL
- SeriLog
- Newtonsoft.Json

## Getting Started
 - Download The Project Or Go To Cloning
 ```bash
git clone https://github.com/hurdenizyener/AssessmentBackend.git
```
- To Use Your Own Database Path , You Need To Update The WebAPI/appsettings.json File
 ```bash
"ConnectionString": "Server=localhost;Database=MyDatabase;UserId=User;Password=123456"
```
### Database Configuration

1. Set As Startup Project WebAPI
2. Open Package Manager Console
3. Default Project DataAcces
 ```bash
Add-Migration Init
Update-Database
```


## Features
- Creating An Invoice From A Json File
