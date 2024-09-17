using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    private readonly float G = 300f; //Decrease ths value to slow movement of planets

    [SerializeField] private CelestialBody[] celestials;

    private void Start()
    {
        InitialVelocity();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        RotatePlanets();
    }

    private void ApplyGravity()
    {
        foreach (CelestialBody a in celestials)
        {
            foreach (CelestialBody b in celestials)
            {
                if (!a.Equals(b))
                {
                    Rigidbody rbA = a.GetComponent<Rigidbody>();
                    Rigidbody rbB = b.GetComponent<Rigidbody>();

                    float massA = rbA.mass;
                    float massB = rbB.mass;
                    float radius = Vector3.Distance(a.transform.position, b.transform.position);

                    Vector3 forceDirection = (b.transform.position - a.transform.position).normalized;
                    float forceMagnitude = (G * massA * massB) / (radius * radius);

                    rbA.AddForce(forceDirection * forceMagnitude);
                }
            }
        }
    }

    //Orbit
    private void InitialVelocity()
    {
        foreach (CelestialBody a in celestials)
        {
            foreach (CelestialBody b in celestials)
            {
                if (a != b)
                {
                    Rigidbody rbA = a.GetComponent<Rigidbody>();
                    Rigidbody rbB = b.GetComponent<Rigidbody>();

                    float massB = rbB.mass;
                    float radius = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);
                    Vector3 initialVelocity = a.transform.right * Mathf.Sqrt((G * massB) / radius);
                    rbA.velocity += initialVelocity;
                }
            }
        }
    }

    // Rotate each planet around its axis
    private void RotatePlanets()
    {
        foreach (CelestialBody celestial in celestials)
        {
            celestial.Rotate();
        }
    }
}
