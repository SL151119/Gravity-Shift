using UnityEngine;

public class AsteroidMovementService : IAsteroidMovement
{
    private readonly Transform _asteroidTransform;
    private readonly Transform _earthTransform;
    private readonly float _orbitSpeed;
    private readonly float _rotationSpeed;

    public AsteroidMovementService(Transform asteroidTransform, Transform earthTransform,
                            float orbitSpeed, float rotationSpeed)
    {
        _asteroidTransform = asteroidTransform;
        _earthTransform = earthTransform;
        _orbitSpeed = orbitSpeed;
        _rotationSpeed = rotationSpeed;    }

    public void OrbitAroundEarth()
    {
        _asteroidTransform.RotateAround(_earthTransform.position, Vector3.up, _orbitSpeed * Time.deltaTime);
    }

    public void RotateAroundAxis()
    {
        _asteroidTransform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}