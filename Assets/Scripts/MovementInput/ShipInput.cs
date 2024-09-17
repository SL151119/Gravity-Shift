using UnityEngine;

public class ShipInput : IShipInput
{
    private readonly PlayerControls _controls;

    public float Thrust { get; private set; }
    public float Strafe { get; private set; }
    public float Roll { get; private set; }
    public Vector2 PitchYaw { get; private set; }
    public bool IsBoosting { get; private set; }

    public ShipInput(PlayerControls controls)
    {
        _controls = controls;
        AssignInputEvents();
    }

    private void AssignInputEvents()
    {
        _controls.SpaceShip.Thrust.performed += context => Thrust = context.ReadValue<float>();

        _controls.SpaceShip.Strafe.performed += context => Strafe = context.ReadValue<float>();

        _controls.SpaceShip.Roll.performed += context => Roll = context.ReadValue<float>();
        
        _controls.SpaceShip.PitchYaw.performed += context => PitchYaw = context.ReadValue<Vector2>();
        
        _controls.SpaceShip.Boost.performed += context => IsBoosting = true;
        _controls.SpaceShip.Boost.canceled += context => IsBoosting = false;
    }
}

