# Codificación y Pruebas


## Codificación


## Prototipos


### Prototipo 1

El código del prototipo 1 se encuentra en la *realise* [V1.0.0](https://gitlab.iessanclemente.net/damo/a22ivancp/-/releases/V1.0.0)

En esta etapa del proyecto me he centrado en el apartado de los datos. Tanto generar los datos estáticos del juego (estadísticas del jugador con sus pokemons), como en los dinámicos (guardado en JSONs los datos más básicos como es el estado del jugador en el mundo).

Para generar la base de datos necesarios tuve que hacer un archivo .java que recoge los datos automáticamente.
```java

private void takeSpritesUpdates(int pokemonID) {
        try {
            String pokemon = generatePokedexData(pokemonID);

            // Analizar JSON y extraer valores
            JsonObject jsonObject = JsonParser.parseString(pokemon).getAsJsonObject();
            JsonObject sprites = jsonObject.getAsJsonObject("sprites");
            String value1 = sprites.get("back_default").getAsString();
            String value2 = sprites.get("front_default").getAsString();

            // Actualizar la base de datos

            byte[] back = spriteArray(value1);
            byte[] front = spriteArray(value2);

            updateDatabase(pokemonID,front,back);

            System.out.println("Database updated successfully.");
        } catch (SQLException e) {
            System.err.println("Error updating the database: " + e.getMessage());
        }
    }

    private byte[] spriteArray(String url) {
        byte[] resu;
        try {
            URL sprite = new URL(url);
            InputStream in = sprite.openStream();

            BufferedInputStream br = new BufferedInputStream(in);
            resu = br.readAllBytes();

        } catch (MalformedURLException e) {
            throw new RuntimeException(e);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        return resu;
    }

    private String generatePokedexData(int numberPokemon) {
        StringBuilder value= new StringBuilder();
        try {
            URL pokedex = new URL("https://pokeapi.co/api/v2/pokemon/"+numberPokemon);
            InputStream in = pokedex.openStream();

            BufferedReader br = new BufferedReader(new InputStreamReader(in));

            String line = "";
            while ( (line = br.readLine())!=null){

                value.append(line);
            }
        } catch (MalformedURLException e) {
            throw new RuntimeException(e);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        return value.toString();
    }

    private void updateDatabase(int pokemon, byte[] front, byte[] back) throws SQLException {
        Connection connection = DriverManager.getConnection(
                "jdbc:sqlite:C:/Users/ivanc/Desktop/PreparateBBDD/src/main/resources/dbPokemon",
                "", "");

        String updateSQL = "UPDATE POKEMON SET SPRITE_FRONT = ?, SPRITE_BACK = ? WHERE POKEDEX_ID = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(updateSQL)) {
            preparedStatement.setBytes(1, front);
            preparedStatement.setBytes(2, back);
            preparedStatement.setInt(3, pokemon); // Ajusta esta línea según tu lógica

            int rowsAffected = preparedStatement.executeUpdate();
            System.out.println(rowsAffected + " rows updated.");
        } finally {
            if (connection != null && !connection.isClosed()) {
                connection.close();
            }
        }
    }

```

A parte, también trabajé en código del proyecto para mejorar algunos datos más básicos como es el selector de inicial y la movilidad del jugador.


|Funcionalidad|Realizado|
|--|--|
|Tabla Pokemons DDBB|Si|
|Tabla Movimientos DDBB|En proceso|
|Tabla Items DDBB|No|
|Obtener datos DDBB|En proceso|
|Menu de eleccion de inicial|Si|
|Código pokemons salvajes|En proceso|
|Jugador datos guardados|Si|


### Prototipo 2

En el [**segundo prototipo**](https://gitlab.iessanclemente.net/damo/a22ivancp/-/releases/V2.0.0) de este proyecto he implementado características primordiales, como pueden ser los layouts de combate y de datos que proporcionamos del jugador. Con esto logro centrarme en las partes mas técnicas del juego, realizando muchos cálculos con los datos que guardo en la **Base de Datos**.

|Funcionalidad|Realizado|
|--|--|
|Obtención de datos BBDD | Si|
|Tabla de Movimientos del juego | Si|
|Generadores de movimientos y pokemons | Si|
|Opciones de combate | Si|
|Menu de juego | Si|
|Cambios de escena con guardado de ubicación | Si|
|Correcta implentacion de los datos json| En proceso|
|Aumento de dificultad y de experiencia de combate | Si|
|Aprendizaje de movimientos en mitad de combate | Si|
|Evoluciones | En proceso|
|Captura de pokemons nuevos | En proceso|
|Pelea contra rivales y obtención de dinero en el juego | Si|
|Generación de mundo | En proceso|
|Animaciones combate | Si|

#### Inovación

En el juego, hemos logrado acceder a la base de datos usando C#, obteniendo así grandes cantidades de datos mediante el uso de algunos plugins/herramientas. Para ello, utilizamos [NuGet](https://www.nuget.org/), la página oficial para obtener librerías para C#, que también trabaja con la página oficial de [SQLite](https://sqlite.org/download.html), entre otras.

Fue difícil, ya que encontrar un DLL de sqlite3 que funcionara era complicado, pero logré implementarlo y finalmente pude realizar mi cometido, usando librerías SQLite3 sin ningún problema.


#### Pruebas

Probar el funcionamiento de las opciones en combate fue un arduo trabajo. Tuve que reducir los tiempos entre mensajes proporcionados por el sistema para el jugador y modificar los valores de algunos pokemons para comprobar su eficacia:

        -> Ganar combate (derrotar a todos y devolviendo la recompensa, volviendo al escenario del mundo actual)
        -> Perder combates (perder con todos tus pokemons y volver directamente al ultimo punto de cura para restaurar todo)
        -> Ganar experiencia( Comprobar que la ecuacion funciona correctamente, chequeando comportamiento con diferentes pokemons y con diferentes niveles[10 pruebas en total])
        -> Aprender Movimiento (tanto preguntando si quiere aprender el movimiento como si no le hace falta preguntar, generando 2 valores boolean)
        -> Cambiar pokemon mitad de combate(Guarda el estado del guardado y somete al nuevo a este combate, guardando los datos y podiendo usar los datos del nuevo en el combate)
        -> Perder Pokemon ( Opcion de huir o cambiar de pokemon)
        -> Perder pokemon Contrincante( Sin opcion de huir y sin alterar mi pokemon, sin llegar a realizar ningún moviento más el mismo)


### Prototipo 3

En el [**tercer prototipo**](https://gitlab.iessanclemente.net/damo/a22ivancp/-/releases/V2.0.0) se añadieron características a mayores en los menus (Pokedex, Salir...) y se perfilaron algunos detalles que hacen del código mas manejable y ser reutilizable. Además, tambien se integraron los entrenadores, los spawns de los enemigos salvajes y se amplio el mundo, añadiendo a su vez, lugares para curarse en la travesia.

|Funcionalidad|Realizado|
|--|--|
|Evoluciones | Si|
|Guardados de estado mejorado | Si|
|Obtención de items | Si|
|Utilización de items | Si|
|Obtención de información general de los rivales | Si|
|Spawns que sirven para la cura de los jugadores | Si|
|Aprendizaje de movimientos en mitad de combate | Si|
|Generación de mundo | Si|

#### Pruebas

Tras varios intentos y pruebas logré implementar los dialogos a los entrenador con el combate de después:

        -> Insertar primero el texto y esperar a que al acabar de hablar salte el combate.
        -> Recordar que ya se peleo con el contrincante.

Además de los cambios de ubicación en tren, sin alterar por completo el mapa, ni que salte todo el rato de ubicación de manera recursiva.
        

Para checkear la pokedex tuve que probar los 3 posibles casos(NO CONOCIDO, CONOCIO, ATRAPADO), y comprobar que se mantengan tras el guardado y la carga de los datos.

El guardado de la partida y la carga fue complicada de lograr mas no imposible. Tuve que cambiar la ruta de este muchas veces hasta descubrir cual carpeta se mantiene en el proyecto tras hacerle el buid. Al final, lo logre guardandolo en StreamingAssets.
        





