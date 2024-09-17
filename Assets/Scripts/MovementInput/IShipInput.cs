using UnityEngine;

public interface IShipInput
{
    float Thrust { get; }
    float Strafe { get; }
    float Roll { get; }
    Vector2 PitchYaw { get; }
    
    bool IsBoosting { get; }
}
