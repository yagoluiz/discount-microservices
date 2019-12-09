# Discount - Microservices

Microservice responsible for submitting discount data information via gRPC to [product microservice](https://github.com/yagoluiz/product-microservices) (developing).

## Data information

Data is stored in Postgres database. The scripts for table generation and initial data are present in the **sql folder**.

## Instructions for run project

Run project via docker or via Visual Studio (F5 or CTRL + F5) or Visual Studio Code (dotnet core CLI or tasks project).

### Container

* Docker:

`docker build -t discount-microservices .`

* Docker compose:

`docker-compose up -d .`