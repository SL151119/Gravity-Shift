# Gravity Shift

## TT for Paconey Studio

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
- **Keyboard**: Left Shift  
- **Gamepad**: Right Shoulder  

---

## Terms of Reference

You control a spaceship with a joystick in 3D space. The ship must move according to the logic of space (skidding when turning, weightlessness—the more naturally it is implemented, the better). 

The goal is to fly to the planet, avoiding obstacles such as asteroids, which are spawned at the beginning of the game. These asteroids orbit around the planet's axis in random order and rotate around their own axis. 

When the ship collides with an asteroid, there is a small camera shake, damage text appears, and the ship gets knocked back slightly. 

Additionally, a radius should be displayed around the ship. When the ship enters this radius, it will automatically collect resources (coins). A hook will spawn from the ship, move toward the coin, collect it, and return to the ship.
