using Cinemachine;
using TMPro;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Header("Ship Knockback")]
    [SerializeField] private Rigidbody shipRigidbody;
    [SerializeField, Range(50f, 100f)] private float knockbackForce = 100f;

    [Header("Camera Shake")]
    [SerializeField, Range(3f, 10f)] private float shakeIntensity = 6f;
    [SerializeField, Range(1f, 2f)] private float shakeDuration = 1.2f;

    [Header("Text Settings")]
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField, Range(2f, 5f)] private float _shakeAmount = 5f; // Amount of text shake
    [SerializeField, Range(2f, 3f)] private float _shakeDuration = 2f; // Duration of the text shake

    private ICameraShake _cameraShake;
    private IDamageText _damageText;
    private IShipKnockback _shipKnockback;
    private ICollisionHandler _collisionHandler;
    private ILevelRestarter _levelRestarter;

    private void Awake()
    {
        _cameraShake = new CameraShake(virtualCamera, shakeIntensity, shakeDuration);

        _damageText = new DamageText(_shakeAmount, _shakeDuration, _textMeshPro);

        _shipKnockback = new ShipKnockback(shipRigidbody, knockbackForce);

        _levelRestarter = new LevelRestarter();

        _collisionHandler = new ShipCollisionHandler(_cameraShake, _damageText, _shipKnockback, _levelRestarter);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collisionHandler.OnCollisionEnter(collision);
    }

    private void Update()
    {
        _cameraShake.UpdateShake();
    }
}
