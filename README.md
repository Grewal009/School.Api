### Command to run/restart Docker container (MS SQL Server)

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password1." -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
