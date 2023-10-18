![Braise Engine Logo](https://raw.githubusercontent.com/AlienTina/BraiseEngine/master/BraiseEngineTemplate/Icon.bmp)
# BraiseEngine
A game engine based on Monogame, made to be a middle ground between the freedom of a framework, and the abstraction of a game engine.

# Usage
-Build the repo.
-Create a new Monogame Project.
-Import the built DLL
-Change the inherited class of Game1 to Core and import BraiseEngine
-add the line `Core.Instance = game;` right before `game.Run();` in Program.cs
(optional): change the Game1 class to only include the base functions.
