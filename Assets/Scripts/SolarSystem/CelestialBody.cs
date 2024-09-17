using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField] private float rotationPeriod;
    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = 360 / rotationPeriod;
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
