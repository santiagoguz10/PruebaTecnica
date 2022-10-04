# PruebaTecnica Api GranTitan



  1.Endpoint de creación de nuevas ruletas que devuelva el id de la nueva ruleta creada

2. Endpoint de apertura de ruleta (el input es un id de ruleta) que permita las
posteriores peticiones de apuestas, este debe devolver simplemente un estado que
confirme que la operación fue exitosa o denegada.

3. Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36)
o color (negro o rojo) de la ruleta una cantidad determinada de dinero (máximo
10.000 dólares) a una ruleta abierta.
nota: este enpoint recibe además de los parámetros de la apuesta, un id de usuario
en los HEADERS asumiendo que el servicio que haga la petición ya realizo una
autenticación y validación de que el cliente tiene el crédito necesario para realizar la
apuesta.

4. Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el
resultado de las apuestas hechas desde su apertura hasta el cierre.
El número ganador se debe seleccionar automáticamente por la aplicación al cerrar
la ruleta y para las apuestas de tipo numérico se debe entregar 5 veces el dinero
apostado si atinan al número ganador, para las apuestas de color se debe entrega 1.8
veces el dinero apostado, todos los demás perderán el dinero apostado.
nota: para seleccionar el color ganador se debe tener en cuenta que los números
pares son rojos y los impares son negros. 

5. Endpoint de listado de ruletas creadas con sus estados (abierta o cerrada)


#Instalación: 

Ejecución de Docker: docker-compose

Abrir Postman

Importar JSON de configuración

Ejecución de metodos


1. POST http://localhost:5000/api/roulette  
2. GET http://localhost:5000/api/roulette  
3. PUT http://localhost:5000/api/roulette/{{roulette_id}}/OpenRoulette
4. POST http://localhost:5000/api/roulette/{{roulette_id}}/BetRoulette 
5. PUT http://localhost:5000/api/roulette/{{roulette_id}}/CloseRoulette 




![image](https://user-images.githubusercontent.com/31780075/193905711-df794009-d568-469e-9b4e-b3f0ab7a7d2e.png)


![image](https://user-images.githubusercontent.com/31780075/193905821-5dd94139-854f-4c06-bdb4-1ced091fb286.png)








