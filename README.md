# Game Implementation README

## Overview
This repository contains a game implementation featuring 4 events and player movement. It includes functionality for player movement, object pickup and drop, and UI interactions.

## Prefabs
- **Player:** Represents the player character in the game.
- **Grabble Sphere:** A sphere object used for grabbing and dropping other objects.
- **A, B, C Boxes:** Three types of boxes present in the game environment.

## Scripts
### Player
- **PlayerMovement:** Handles player movement within the game.
- **MouseInputAction:** Triggers click events.
- **HandTrigger:** Detects when the hand tip contacts the grabble object and triggers corresponding events.

### GrabbleSphere
- **IGrabble Interface:** Interface for grabbable objects.
- **GrabbleObject:** Allows the sphere to grab and detach from the tip of the hand, triggering events accordingly.

### A, B, C Prefabs
- **AbstractBaseClass:** Base class for A, B, C containers.
- **Container_A, Container_B:** Derived classes that receive and trigger events when the sphere hits them.
- **Container_C:** Another derived class that also receives and triggers events when the sphere hits it.

## Features
- **UI Integration:** When the player picks up the sphere, an event triggers to open a UI. Upon first pickup, the UI displays the text "a stone to lift coffin". Subsequently, the UI contains 3 categories with dummy buttons and scores points for the 3rd category.
- **Render Texture:** Added render texture to display which instrument is picked up.
- **Event Handling:** Different events occur when the sphere is dropped on different boxes, as per the documented specifications.
- **Audio Integration:** Added audio effects for object pickup and drop.

## Usage
1. Clone the repository.
2. Project is made in Unity 2022.3.9f1.
3. Utilize the provided prefabs and scripts to implement player movement, object pickup and drop, and UI interactions.
4. Customize as needed for your game.

## Contribution
Contributions are welcome! If you have any suggestions, bug fixes, or feature implementations, feel free to open an issue or create a pull request.

## License
This project is licensed under the [MIT License](LICENSE).
