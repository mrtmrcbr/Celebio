# Celebio
in this app we use dotnet core 2.2 on backend and mysql for database

## backend instalation and running guide

### clone the project

```sh
git clone https://github.com/mrTmr12/Celebio.git

cd Celebio

git checkout backend

cd CelebioBackend
```

### run with docker
mysql service is included docker file

```sh
docker-compose -f docker-compose.yml up
```

### run with dotnet core 2.2 sdk 
before to run with sdk you have to install mysql in your local machine

```sh
dotnet restore

dotnet build

dotnet run 
```