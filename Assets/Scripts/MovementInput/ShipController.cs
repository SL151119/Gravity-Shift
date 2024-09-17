public class ShipController
{
    private readonly IShipMovement _movement;
    private readonly IShipInput _input;

    public ShipController(IShipMovement movement, IShipInput input)
    {
        _movement = movement;
        _input = input;
    }

    public void UpdateShipMovement()
    {
        _movement.ApplyThrust(_input.Thrust, _input.IsBoosting);
        _movement.ApplyStrafe(_input.Strafe);
        _movement.ApplyPitch(_input.PitchYaw);
        _movement.ApplyYaw(_input.PitchYaw);
        _movement.ApplyRoll(_input.Roll);
    }
}
