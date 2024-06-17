# Estudio preliminar

## 1. Descripción del proyecto

![alt text](../img/pokemon.jpg)

Mi aplicación se llama `Pokémon Santiago de Compostela`. En este proyecto se va a desarrollar un videojuego que utiliza elementos de la enorme saga de juegos `Pokémon`, en el que el jugador es un **Estudiante de Programación Pokemon** (EPP) de Santiago de Compostela y debe superar su etapa estudiantil. Para ello, tendrá que enfrentarse a numerosas pruebas que desarrollará el profesorado del centro y tendrá que llegar a final de mes con el dinero suficiente para poder vivir en Santiago, avanzando así en la trama. El juego actualmente acabaría en el primer trimestre estudiantil.

### 1.1. Justificación del proyecto

Este proyecto tiene cierta importancia a nivel personal, porque mi objetivo desde que descubrí que quería ser programador, fue llegar a realizar un juego de Pokemon **personalizado** y que las siguientes generaciones disfruten del juego como yo lo hice cuando yo era pequeño. También quiero que sea **2D** porque así fueron los originales.

Sin embargo, la tarea no es fácil, ya que quiero implementar:
- Una **base de datos** con toda la información necesaria para que en el proyecto pueda ser portable.

- **Las animaciones** de todas las entidades del juego.

- Mantener **actualizados** los valores de la partida mostrando los cambios al usuario.

- Movilidad de los NPCs personalizada.

- Obtener todos los recursos necesarios (sobre todo Sprites).

- El generar ecuaciones para que los ataques del jugador surjan más o menos efecto dependiendo del enemigo contra el que se enfrente.

- El orden de aprendizaje de los movimientos del pokémon.

Estas son solo algunas de las características a implementar en el proyecto. Se podrán desarrollar más dependiendo del margen de tiempo para realizarlo.

### 1.2. Funcionalidades del proyecto


Las funcionalidades más importantes del proyecto serán:

- Sistema de combate entre rivales, enemigos o *pokemons*.
- Sistema de captura de pokemons para completar un equipo.
- Desafios y tareas a cumplir por medio del camino que ayudarán a tu supervivencia en Santiago.
- Superación de las asignaturas del primer trimestre.

### 1.3. Estudio de necesidades

La app tendrá un **menú interactivo** que funcionará con el ratón, incluyendo los de combate. Además aportará ciertas **costumbres gallegas** y dará a conocer un punto de vista más **universitario**. Esto será lo que lo diferencie de los juegos actuales del mercado. Además, pocas cosas son interactivas con el teclado, lo cual lo hace más cómodo al uso.

### 1.4. Personas destinatarias

Este proyecto, llamado Pokémon Santiago de Compostela, está dirigido a cualquier persona que quiera divertirse, aprendiendo costumbres gallegas y conociendo más la vida universitaria de Santiago de Compostela.

### 1.5. Modelo de negocio

El proyecto está pensado para uso personal. Sin embargo, en el caso de sacarlo al mercado estaría sujeto a un contrato sobre los derechos de uso de los datos con la compañia propietaria de *Pokemon*. Para rentabilizar el juego se podría hacer algunos patrocinos como; Estrella Galicia, Renfe y algunos pubs de Santiago de Compostela.

## 2. Requerimientos

- Base de datos SQL.
- Programación en C# en Unity.
- Utilización de dotnet.
- Animaciones de Unity.
- Transiciones de Unity.
- Uso de Prefabs de Unity.
- Recursos gratuitos de la *store* de Unity.
- Uso de ecuaciones que alteran el daño del dado y recibido.
- *Sprites* de avatares para la historia que se muevan.
- Guardados de estado del juego usando *jsons* como sistema de almacenamiento o la misma base de datos de antes para los *pokemons*.
- Uso de *DTOs*.
