# Timeline Travel

Timeline Travel is a very hard space shoter game with 10 stages about traveling through timelines
you can play this game [Here](https://vitorjusto.itch.io/timeline-travel) 

Godot 4.1.1 Stable Mono · C# · Solo dev

## Technical decisions

**Object Pooling**
- On the LoaderManager, the game hold packedScenes of already instantiated scenes instead of load the same scene every time. Saving performace and loading time.

**State Pattern**  
- I used State pattern for different bosses behaivor, becoming easier to develop them. The idea for this patten is the current state call the next state depending the condition for calling the next state, usually when the Animation/Attack ended and the boss call the next attack.
- This approach have 2 Advanages:
  - **Can easily change the state in the middle of another state**: mostly used when the boss reach on an certain HP to change the boss phase, an state can be assinged on the middle of another state.
  - **Can reuse others states**: The exploding state is an example, every boss use the same explosing animation because of this state;

- The 10 bosses uses this patten, bosses from levels 1 (have simple attacks), 3 (He uses only to toggle attack and moviment states and uses some animations, and cycle around them) and level 10 (have simple attacks)) only have one phases, while other bosses have more than 1 phases.
- The final boss, for being the most complex dosen't use the interface the same way as the other bosses, mainly beacuse each state is an standalone scene. 
  
**Strategy Pattern**
- When I develop this game, I didn't knew the collision layers and mask system, ending up with every Collisionbody in the same layer/mask. Instead, the collision check was made using strategy pattern. For example, if the player detect an object with ```IEnemyProjectile``` interface, the player take damage based from the ```GetDamage()``` function the object return.
- Despise having the collision layer system in godot for colision check, this aproach have an avantage to calling function from the objects directily instead relaing from signals, However, the main problem is every object detecting evething.

**Singleton Pattern**
- Some objects like player or enemy spawner are instaniated once, and can be call from anywhere, so objects like this, I used the Singleton Patten.
- But, this isn't an accurate implementation of Singleton because the classes it dosen't have an private constructor. The reason why is for the fact that godot only support partial classes for node objects, and private constructors dosen't work. The workaround I made is setting the private static property on the `_Ready()` function. While working for most of the time, it might happen to have some problems when the game is loading for the first time. So I made de implementation carefully.

**Enemy Section Factory**
- The game spawn enemies by sections, the condition to spawn the next section of the enemy is an set time or if have no enemy on screen.
- Each enemy have an dummy object and is instantiated when the game is loading. So the `EnemySection` class have an list of enemies instantiated, and this list use an interface called `IEnemyDummy`, and each enemy have an especific class (called Dummy) with the interface (theses dummy classes aren't the real enemies objects, they just hold informations to spawn enemy on the right time). With theses dummys objects is possible to configurate especifics setting for each enemy without dependencies, such as position, speed and the projectile type.

**Flag Interface**
- Some enemies doesn't have an explosion animation (e.g. Lightning), so Initially, I thought about adding a function to `IEnemy` called something like `AllowExplode`, but I would have to implement this method to all enemies. So, I ended up creating the `INonExplodable` interface and used it only on enemies that don't explode. Then, before the explosion animation starts, will check if the object implements `INonExplodable`

## Running the project
- Godot 4.1.1 Mono
- .NET 6
- Clone the repo, open `project.godot` in Godot
- No external dependencies

## Credits
"Pixel Explosion" by JROB774 licensed Creative Commons: https://opengameart.org/content/pixel-explosion-12-frames

Background Timeline 5 Photo by paul voie from Pexels (photo modified in-game): https://www.pexels.com/photo/clouds-2627945/

Background Boss Rush photo by Philippe Donn from Pexels: https://www.pexels.com/pt-br/foto/estrelas-1257860/

Everything else made by [vitorjusto](https://github.com/vitorjusto)


