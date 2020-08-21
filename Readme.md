#################################################### DOCKER ############################################################
# PREREQUIREMENTS:
# - Docker Windows
# - Shared dir for volume(to set in settings) for instance:
#	C:\Users\M6800\source\repos\ewidencja\Aplikacja-do-ewidencji-czasu-pracy\Docker

DOCKER MSSQL DB:
# Download the MSSQL image
docker pull mcr.microsoft.com/mssql/server

# Run container, into -v C:\Users\M6800\source\repos\ewidencja\Aplikacja-do-ewidencji-czasu-pracy\Docker
# Please put own path to project dir with docker volume

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password1!" `
-v C:\Users\M6800\source\repos\ewidencja\Aplikacja-do-ewidencji-czasu-pracy\Docker:/var/opt/mssql `
--name DB-1 `
-p 1433:1433 -d mcr.microsoft.com/mssql/server:latest

# show runing containers (frome here you get containerID)
docker ps -a

# Run container with bash terminal
# <containerID>  for instance 7ee18f1e91fe 
docker exec -it <containerID> /bin/bash

# Run SQLcmd:
mssql@7ee18f1e91fe:/opt/mssql-tools/bin$ ./sqlcmd -S localhost -U SA -P "Password1!"

# Scritps execution SQLcmd
mssql@7ee18f1e91fe:/opt/mssql-tools/bin$ ./sqlcmd -S localhost -U SA -P "Password1!" -i /var/opt/mssql/SQLQuery1.sql

####################################################### DB ##############################################################
# Scaffolding sytax
PM> Scaffold-DbContext "Server=127.0.0.1,1433;Database=Ewidencja;User ID=sa;Password=Password1!;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

# DB connection string in C#