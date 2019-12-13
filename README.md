# Discount - Microservices

![](https://github.com/yagoluiz/discount-microservices/workflows/Docker%20Image%20CI/badge.svg)

Microservice responsible for submitting discount data information via gRPC [product microservice](https://github.com/yagoluiz/product-microservices).

## Data information

Data is stored in Postgres database. The scripts for table generation and initial data are present in the **sql folder**.

## Instructions for run project

Run project via docker, via Visual Studio (F5 or CTRL + F5), Visual Studio Code (tasks project) or dotnet CLI.

### Container

* Docker:

`docker build -t discount-microservices .`

Run project [product microservice](https://github.com/yagoluiz/product-microservices):

`docker build -t product-microservices .`

* Docker compose:

`docker-compose up -d .`
