# Análisis: Requisitos del sistema

## Descripción geral

En su mayoría, el proyecto que estoy llevando a cabo constará de muchos valores estáticos que sacaré de una base de datos preparada. Todos mis datos e imágenes serán sacados de una [*API*](https://pokeapi.co/api/v2/pokedex/2/). Filtraré la información significativamente para quedarme con los *pokemons* de primera generación.

Además también usaré algunos **métodos** para guardar la posición del jugador en el mapa. Se almacenarán datos personales como es el nombre, el dinero y el equipo pokemon y de todos los objetos recolectados.

Las **matemáticas** serán esenciales ya que, en este tipo de videojuegos, hay muchas variables desconocidas para la mayoría de los usuarios que afectarán el daño recibido, el ataque lanzado, las dificultades...

## Funcionalidades

| Acción          | Descripción                     |
|-----------------|---------------------------------|
| Interacciones con el juego | El usuario podrá moverse por todo el mapa, chocando con algunos elementos del juego, pudiendo abrir puertas e interactuando con NPCs (Personajes No Jugables) |
| Aplicación de ITEMS | Podrá darle items a los pokemons con los que juega a lo largo de la historia, aplicando sus efectos a este |
| Interfaz de combate | El jugador mandará ordenes al pokemon que tenga contra el enemigo en una sucesión de turnos |
| Obtener ITEMS | Podrá encontrar los items por el mundo o comprarlos en una tienda que tendra un menú de productos con sus precios [OPCIONAL] |

## Tipos de usuarios

El único tipo de usuario será el jugador. No es necesario ningún usuario con privilegios sobre la aplicación.

## Normativa

- Juego limpio y honesto:

        Se prohíbe el uso de trampas, hacks o cualquier forma de manipulación del juego que pueda proporcionar una ventaja injusta sobre el rival.
        El incumplimiento de esta norma hace que el juego sea aburrido y muy monótono, por lo tanto se pide dejar los intentos de trampas y que se disfrute del juego.

- Protección de Datos y Privacidad:

        Nos comprometemos a proteger la privacidad de nuestros jugadores y sus datos personales.
        Solo recopilamos la información necesaria para operar el juego y nunca compartiremos datos personales con terceros sin consentimiento. [Ley Orgánica 3/2018, de 5 de diciembre, de Protección de Datos Personales y garantía de los derechos digitales (LOPDPGDD)]

- Restricciones de Edad:

        Este juego está destinado a jugadores mayores de 15 años preferentemente. Los menores de edad deben obtener el consentimiento de sus padres o tutores antes de jugar.

- Licencias de Contenido:

        Todos los elementos con licencia en el juego, como personajes, música y arte, son utilizados con permiso.
        La reproducción o distribución no autorizada de estos materiales está estrictamente prohibida y puede resultar en acciones legales.

- Normativas de distribución de software y plataformas:

        En caso de llegar a distribuirlo en GooglePlayStore, necesitaria cumplir las políticas que contienen para sacar al mercado. De contenido, como dije antes, de publicidad o Marketing, de calidad( el cumplimiento de ciertos estandares de la Store), de pago en el caso de que sea necesario (en el mio no), y de privacidad del usuario.