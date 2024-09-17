using UnityEngine;

public class ShipKnockback : IShipKnockback
{
    private readonly Rigidbody _shipRigidbody;
    private readonly float _knockbackForce;

    public ShipKnockback(Rigidbody shipRigidbody, float knockbackForce)
    {
        _shipRigidbody = shipRigidbody;
        _knockbackForce = knockbackForce;
    }

    public void ApplyKnockback(Collision collision)
    {
        Vector3 knockbackDirection = (collision.transform.position - _shipRigidbody.transform.position).normalized;
        _shipRigidbody.AddForce(-knockbackDirection * _knockbackForce, ForceMode.Impulse);
    }
}