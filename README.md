# Zombie Car Arena 🚗🧟

A simple arcade style Unity game where the player drives a car around an arena and tries to hit as many zombies as possible before the timer runs out. The game demonstrates swipe based car control, ragdoll physics, and basic game mechanics such as scoring and spawning.

---
## APK Download

You can download and install the Android version of the game here:

[Download APK](https://github.com/Mystical-Coder/zombie-car-arena/releases/tag/v1.0)

# Gameplay

In this game, the player controls a car in a top-down arena. Zombies spawn randomly and wander around the environment. The objective is to drive into the zombies to eliminate them and increase the score before the game timer reaches zero.

When the car hits a zombie, ragdoll physics is triggered and the zombie collapses. New zombies spawn continuously to maintain gameplay difficulty.

---

# Controls

The car is controlled using **Hot Slide style swipe input**.

| Action       | Control                         |
| ------------ | ------------------------------- |
| Move Car     | Car moves forward automatically |
| Turn Left    | Swipe left                      |
| Turn Right   | Swipe right                     |
| Restart Game | Restart button after timer ends |

The swipe input allows intuitive steering similar to mobile arcade games.

---

# Prometeo Controller Adaptation

The original **Prometeo Car Controller** uses keyboard inputs such as **W, A, S, D** for acceleration and steering. To adapt it for a **Hot Slide-style control scheme**, the steering input was modified to use **horizontal swipe gestures**.

A custom `SwipeInput` script detects finger movement across the screen and calculates a normalized swipe value (`swipeX`). The Prometeo controller was modified to interpret this value as steering input:

* Negative swipe → TurnLeft()
* Positive swipe → TurnRight()
* No swipe → Reset steering angle

This approach makes the gameplay more suitable for **mobile devices and touch interaction**.

---

# Features

* Swipe-based car steering
* Smooth camera following the player
* Zombie spawning system
* Random zombie wandering behavior
* Ragdoll physics when zombies are hit
* Score tracking system
* Game timer
* Restart functionality
* Target performance of 60 FPS

---

# Project Structure

Important Unity folders included in this repository:

```
Assets/
Packages/
ProjectSettings/
```

These are the required folders to open the project in Unity.

---

# Known Issues / Limitations

* Ragdoll physics may occasionally behave inconsistently depending on collision angle.
* Swipe sensitivity may vary slightly across different device screen sizes.
* Zombie AI is simple and does not actively chase the player.
* Multiple ragdoll zombies may reduce performance slightly on lower-end devices.

---

# Tools Used

* Unity Engine
* C#
* Unity Physics System
* Prometeo Car Controller
