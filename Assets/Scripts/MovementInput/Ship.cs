using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [Header("Ship Movement Settings")]
    [SerializeField] private float yawTorque = 300f;
    [SerializeField] private float pitchTorque = 300f;
    [SerializeField] private float rollTorque = 300f;
    [SerializeField] private float thrust = 300f;
    [SerializeField] private float strafeThrust = 300f;

    [Header("Glide")]
    [SerializeField, Range(0.000001f, 1f)] private float thrustGlideReduction = 0.132f;
    [SerializeField, Range(0.000001f, 1f)] private float leftRightGlideReduction = 0.111f;

    [Header("Boost Settings")]
    [SerializeField] private float boostMultiplier = 5f;

    private PlayerControls _controls;
    private ShipController _controller;

    private void Awake()
    {
        _controls = new PlayerControls();
        
        var input = new ShipInput(_controls);

        var movementService = new ShipMovementService(_rb, yawTorque, pitchTorque, rollTorque, thrust,
            strafeThrust, thrustGlideReduction, leftRightGlideReduction,
            boostMultiplier);

        _controller = new ShipController(movementService, input);
    }

    private void FixedUpdate()
    {
        _controller.UpdateShipMovement();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
