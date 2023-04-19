# Authentication
Authentication Service with Dotnet Core 7 



## Author

- [@sheriff-kurdi](https://www.github.com/sheriff-kurdi)



## Tech Stack

**Databse:** PostgreSQL

**Server:** Dotnet core 7 with minimal APIs 



## Used Tools

- [Dotnet Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)

- [EF Core](https://learn.microsoft.com/en-us/ef/core/querying/)

- [swagger](https://github.com/swaggo/swag)

- [xUnit](https://xunit.net/docs/getting-started/netcore/cmdline)

- [GNU make](https://www.gnu.org/software/make/manual/make.html)


## Run Locally

To deploy this project

- Create **postgres database engine**
    with credentials used in **.env.example**

```bash
  make docker.postgres.create
```

- Create **authentication_service** database 
    
```bash
  make update.database
```
    
- Run application

```bash
  make run
```



## Running Tests

To run tests, run the following command

```bash
  make test
```



## Support

For support, email sheriff.kurdi@gmail.com




## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/sheriff-kurdi)
[![twitter](https://img.shields.io/badge/twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/sheriffKurdi)




## Linces

This project linced with MIT

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

