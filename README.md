# [Lerthos]

El proyecto consta de un juego hecho en el motor grafico Unity con el aspecto del codigo desarrollado en c#, ademas, el juego contara con un mando propio para jugarlo. Sera un juego tipo MMO, con mapa y cosas tipicas del genero. En cuanto al mando/controlador, esta por decidir si se hace algun tipo de teclado casero o mando estilo consola. 

## Integrantes del equipo:

- Yikai Zhan
- Diego Ramírez Peinado
- Carlos Mendoza Carpintero
- Miguel Ángel Pascual Collar
- Pablo Martínez-Conde Albizu
- Uberto Alejandro Martínez Rodríguez

## Objetivos del trabajo:

Crear un juego totalmente funcional con un mando diseñado por nosotros, el mando debe ser capaz de ejecutar todas las acciones que diseñemos para dicho juego, y el juego debe obedecer lo que nosotros queramos que este haga a traves de las acciones del mando. 
- El juego contara con un personaje, el cual podremos mover por un mapa principal e incluso podremos cambiar a otros escenarios.
- Dentro del propio mapa habra varios npcs ("non playable character") los cuales nos daran unas misiones o recados para hacer, algunos incluso te recompensaran por ello.
- Aparte de los npcs, habra varios enemigos a los que nos podremos enfrentar.
- El juego se basara en una corta historia, en la que nuestro objetivo es conseguir dinero para que nuestro personaje pueda vivir dentro de la zona del poblado. Para ello el jugador ha de ayudar a los npcs y cumplir misiones. Una vez obtenido el dinero suficiente, habra un npc en el pueblo que se ofrece a construirte la casa por una cantidad de dinero.
- El juego contara con la opcion de pausarse, donde nos aparecera un menu con varias opciones, entre las que posiblemente agregaremos una opcion para guardar el progreso.
Por ultimo, el juego contara con musica y sonidos y posiblemente añadiremos en el menu de pausa algun tipo de forma para modificar el volumen de esta.

## Entorno, diseño y funcionalidad:
![GitHub1](https://user-images.githubusercontent.com/61047659/119157555-99305480-ba55-11eb-896d-3565dac1511a.png)
Modificacion de las animaciones activas dentro del entorno para un npc. Con los parametros MovX y MovY, que obtenemos del codigo que controla al propio npc, modificamos la animacion que se ejecuta. Dentro del animador, lo que estamos viendo es lo que hay dentro de un bloque (en las siguientes imagenes se enseña solo la parte principal del animador, no los bloques por dentro), en este caso observamos que el bloque contiene 4 animaciones diferentes, una para cada direccion a la que el npc puede mirar. Si se hiciese click a "Blend Tree" observariamos que condiciones se ha impuesto a los parametros MovX y MovY para que cada animacion se ejecute. Si se quiere hacer un bloque de animaciones nuevo se tendria que crear otro "Blend Tree" desde el menu principal del animador, y una vez dentro de este nuevo bloque, asegurarnos de que el metodo de mezclado de animaciones esta ajustado a 2D Freeform Cartesian, para que podamos tener 2 parametros definiendo las condiciones de ejecucion. tambien se puede modicar el tiempo de ejecucion de las animaciones y si estas estan en bucle o no.
![GitHub2](https://user-images.githubusercontent.com/61047659/119157575-9c2b4500-ba55-11eb-869c-b2aa456efe97.png)
Arbol de animaciones del personaje principal. Este incluye mas parametros ya que sus animaciones son mas detalladas y variadas. Dentro de cada bloque hay varias animaciones y se va alternando de bloque segun las condiciones impuestas en las flechas (valores de los parametros asignados). Parametros obtenidos del codigo que define al personaje y sus acciones. Por ejemplo, la condicion de pasar de atacando a estar quieto, es que el personaje no se este moviendo, si el personaje nada mas atacar decidiese moverse, el personaje pasaria a mostrar la animacion de moverse.
![GitHub3](https://user-images.githubusercontent.com/61047659/119157584-a0eff900-ba55-11eb-9895-c3e13821ad90.png)
Imagen de parte del codigo y los elementos que forman y hacen funcionar la barra de vida y el indicador del nivel. Se puede observar que esto esta controlado por dos funciones diferentes que se ha creado, una controla los elementos de tipo Visual (carteles e indicadores) y la otra se dedica a las estadisticas del personaje. En la parte de codigo observamos que hay dos funciones visibles (se pueden crear otras personalizadas), una de ellas es Start, la cual solo se acciona una vez (al iniciar el programa). La otra es Update, que se ejecuta cada unidad de tiempo, la unidad de tiempo la define el propio entorno con una variable llamada "Time.deltaTime". Normalmente esta unidad de tiempo es un "frame" lo cual simboliza el tiempo que tarda en actualizarse la imagen.
![GitHub4](https://user-images.githubusercontent.com/61047659/119157606-a64d4380-ba55-11eb-85cf-13ea10a0fe27.png)
En esta imagen podemos observar el juego en marcha dentro del entorno. En el apartado de jerarquia podemos ver que esta dividido en dos. La primera parte "Cave" es el mapa con sus puntos de transporte, suelo, colisionadores personalizados, npcs y enemigos. La segunda parte es debida a una funcion que causa que no se destruyan los objetos al cambiar de escena, esto incluye al personaje, los indicadores y el reproductor y administrador de sonido que hemos creado (de esta forma se conserva el nivel, la vida y todo lo relacionado con estos objetos al cambiar de escena). Por otra parte, el sistema de eventos al atacar a un enemigo, crea los indicadores de daño que se ha creado, que estan programados para desaparecer 1 segundo despues de ser creados, de forma que no se acumulen y ocupen memoria, bajando el rendimiento del juego. Al atacar tambien se ha agregado sonidos al recibir daño.
![GitHub5](https://user-images.githubusercontent.com/61047659/119157614-a8170700-ba55-11eb-91e5-26a77752cacb.png)
En esta foto se puede observar que no hay errores en la consola de la aplicación, lo que quiere decir que no hay ningún error de código o problemas con sonido apreciables por la propia aplicación a primera vista ni incompatibilidades. Obviamente hay algunas cosas que la aplicación no detecta ("bugs") pero por el momento no se ha encontrado ninguno que no haya sido arreglado a día de hoy. Si aparecen errores no decisivos, el juego no se pausa y en la consola nos saldria una alerta amarilla. Si es un error mas serio, normalmente relacionado con el codigo o la referencia a objetos, nos saldria un error rojo y el juego se pararia inmediatamente. Tambien se puede usar la consola para asegurarnos de que alguna parte del codigo se esta ejecutando en caso de duda. Esto se haria incluyendo lo siguiente: Debug.Log("Texto de ejemplo para confirmar");. Esto resulta util cuando pruebas funciones nuevas y no estan funcionando del todo como deberian.
