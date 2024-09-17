using UnityEngine;

public class ShipMovementService : IShipMovement
{
    private readonly Rigidbody _rb;
    private readonly float _yawTorque;
    private readonly float _pitchTorque;
    private readonly float _rollTorque;
    private readonly float _thrust;
    private readonly float _strafeThrust;
    private readonly float _thrustGlideReduction;
    private readonly float _leftRightGlideReduction;

    private readonly float _boostMultiplier;

    private float _horizontalGlide = 0f;
    private float _glide = 0f;

    public ShipMovementService(Rigidbody rb, float yawTorque, float pitchTorque, float rollTorque, float thrust,
        float strafeThrust, float thrustGlideReduction, float leftRightGlideReduction,
        float boostMultiplier)
    {
        _rb = rb;
        _yawTorque = yawTorque;
        _pitchTorque = pitchTorque;
        _rollTorque = rollTorque;
        _thrust = thrust;
        _strafeThrust = strafeThrust;
        _thrustGlideReduction = thrustGlideReduction;
        _leftRightGlideReduction = leftRightGlideReduction;
        _boostMultiplier = boostMultiplier;
    }

    public void ApplyThrust(float thrustInput, bool isBoosting)
    {
        float currentThrust = _thrust;

        if (Mathf.Abs(thrustInput) > 0.1f)
        {
            currentThrust = isBoosting
                ? _thrust * _boostMultiplier
                : _thrust;

            _rb.AddRelativeForce(thrustInput * currentThrust * Time.fixedDeltaTime * Vector3.forward); //fixed
            _glide = _thrust;
        }
        else
        {
            _rb.AddRelativeForce(_glide * Time.fixedDeltaTime * Vector3.forward); // fixed
            _glide = _glide * _thrustGlideReduction;
        }
    }

    public void ApplyStrafe(float strafeInput)
    {
        if (Mathf.Abs(strafeInput) > 0.1f)
        {
            _rb.AddRelativeForce(strafeInput * _strafeThrust * Time.fixedDeltaTime * Vector3.right);
            _horizontalGlide = strafeInput * _strafeThrust;
        }
        else
        {
            _rb.AddRelativeForce(_horizontalGlide *  Time.fixedDeltaTime * Vector3.right);
            _horizontalGlide = _horizontalGlide * _leftRightGlideReduction;
        }
    }

    public void ApplyPitch(Vector2 pitchYaw)
    {
        _rb.AddRelativeTorque(Mathf.Clamp(-pitchYaw.y, -1f, 1f) * _pitchTorque * Time.deltaTime * Vector3.right);
    }

    public void ApplyYaw(Vector2 pitchYaw)
    {
        _rb.AddRelativeTorque(Mathf.Clamp(pitchYaw.x, -1f, 1f) * _yawTorque * Time.deltaTime * Vector3.up);
    }

    public void ApplyRoll(float roll)
    {
        _rb.AddRelativeTorque(roll * _rollTorque * Time.deltaTime * Vector3.back);
    }
}
