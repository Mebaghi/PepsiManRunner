# Pepsi Man Runner (3D)

## Description
This project is a simple 3D endless runner game inspired by the classic Pepsi Man style, developed using Unity.  
The player moves forward automatically and can switch between three lanes to avoid obstacles.  
The game continues until the player collides with an obstacle, which results in a Game Over screen.

The focus of this project is on implementing core gameplay mechanics such as player movement, obstacle spawning, collision detection, scoring, and basic user interface elements.

---

## Gameplay Features
- Automatic forward movement
- Three-lane movement system (left, center, right)
- Random obstacle spawning
- Increasing score based on distance/time
- Best score saved using PlayerPrefs
- Game Over and Restart functionality

---

## Controls
- **A / Left Arrow** → Move Left  
- **D / Right Arrow** → Move Right  

---

## How to Run the Game
1. Open the project in Unity.
2. Load the main game scene.
3. Press the **Play** button in the Unity Editor.
4. Use the keyboard controls to move between lanes and avoid obstacles.

---

## Reflection
In this project, I implemented a simple 3D runner game and gained hands-on experience with several important Unity concepts. One of the main challenges was implementing smooth player movement while restricting the player to three fixed lanes. This helped me better understand how to work with Transform operations and player input inside the Update loop.

Another important part of the project was obstacle management. I learned how to use Prefabs and the Instantiate function to spawn obstacles dynamically at runtime. By randomizing both the lane position and the distance between obstacles, I was able to create more variation in gameplay. Working with Trigger Colliders and the OnTriggerEnter method also helped me understand the difference between physical collisions and trigger-based interactions.

I also implemented a scoring system that increases over time and displays both the current score and the best score during gameplay. Using PlayerPrefs to store the best score allowed the data to persist between game sessions. Additionally, creating a Game Over panel and a Restart button introduced me to basic UI management and scene reloading in Unity.

Overall, this project helped me gain a clearer understanding of the structure of a simple runner game and improved my confidence in working with Unity’s core systems, including movement, collision detection, prefabs, UI, and game state management.

---
