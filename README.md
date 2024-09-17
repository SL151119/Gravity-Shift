# Gravity Shift

## TT for Paconey Studio

### What was used to create the project
- **Unity Version 2022.3.34f1**
- **URP**
- **DoTween**
- **UniTask**
- **VFX**
- **Shader Graphs**
- **Particle System**
- **New Input System**

### Controls

**Thrust (back and forward)**  
- **Keyboard**: S, W  
- **Gamepad**: LeftStick/Down, LeftStick/Up  

**Strafe (left-right)**  
- **Keyboard**: A, D  
- **Gamepad**: LeftStick/Left, LeftStick/Right  

**Roll (“tilt left - tilt right”)**  
- **Keyboard**: Q, E  
- **Gamepad**: LeftTrigger, RightTrigger  

**PitchYaw (camera control)**  
- Mouse or RightStick on Gamepad  

**Boost**
**Note: for Boost, the button must be held down for 0.2 seconds*
- **Keyboard**: Left Shift  
- **Gamepad**: Right Shoulder  
---
## Gameplay Screenshot
![Gameplay Screenshot](https://i.ibb.co/mzGLxLr/Gameplay-Screenshot.png)
---

## Terms of Reference

You control a spaceship with a joystick in 3D space. The ship must move according to the logic of space (skidding when turning, weightlessness, the more natural it is implemented, the better). 

The goal is to fly to the planet (in my case it's Earth, level will restart after collide with Earth), avoiding obstacles such as asteroids, which are spawned at the beginning of the game. These asteroids orbit around the planet's axis in random order and rotate around their own axis. 

If the ship collides with an asteroid, there is a small shake of the camera, the damage text appears and the ship should fly away a little.

A radius should be displayed around the ship, when it hits it, the ship automatically collects resources (coins) - a hook will spawn from the ship, which moves to the coin, picks it up and moves back to the ship.
