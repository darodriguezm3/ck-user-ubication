# Proyecto de Software - Backend

## Descripción

Este proyecto incluye un backend desarrollado y dockerizado, que ha sido desplegado en la siguiente URL: [https://ckuserapp-faet3oqt.b4a.run/](https://ckuserapp-faet3oqt.b4a.run/). 

## Estructura del Proyecto

### Carpeta `sp/`
En esta carpeta se encuentran almacenados todos los stored procedures utilizados por la base de datos del proyecto. Estos stored procedures se usan para realizar operaciones específicas con mayor eficiencia y control.

### Queries
Igualmente, en sp se encuentran un .sql con todas las queries necesarias para la creación y configuración de la base de datos, incluyendo:
- Scripts para la creación de tablas
- Definición de índices y restricciones
- Inserción de datos base

### Backend Dockerizado
El backend ha sido empaquetado en un contenedor Docker, lo que permite su fácil despliegue y portabilidad. Este backend se conecta con la base de datos y gestiona la lógica del negocio mediante una API. Puedes acceder a la aplicación desplegada en:

[https://ckuserapp-faet3oqt.b4a.run/](https://ckuserapp-faet3oqt.b4a.run/)

## Tecnologías Utilizadas
- Docker
- API
- Base de datos SQL
- Stored Procedures

## Despliegue
La aplicación está actualmente desplegada en un entorno de nube, lo que permite su acceso de forma pública a través de la URL proporcionada.

## env
Se creó una variable de ambiente que contiene las credenciales de la base de datos donde también se puede colocar el puerto en el que se va a hacer el despliegues

