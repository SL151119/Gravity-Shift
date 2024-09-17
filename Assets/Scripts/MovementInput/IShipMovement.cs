using UnityEngine;

public interface IShipMovement
{
    void ApplyThrust(float thrust, bool isBoosting);
    void ApplyStrafe (float strafeInput);
    void ApplyPitch(Vector2 pitchYaw);
    void ApplyYaw(Vector2 pitchYaw);
    void ApplyRoll(float roll);
}
