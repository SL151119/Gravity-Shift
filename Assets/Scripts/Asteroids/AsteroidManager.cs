using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform earthTransform;

    [Header("Asteroid Count and Distance")]
    [SerializeField, Range(10, 50)] private int asteroidCount = 50;
    [SerializeField, Range(900f, 1000f)] private float minOrbitRadius = 900f;
    [SerializeField, Range(1000f, 1100f)] private float maxOrbitRadius = 1000f;
    [SerializeField, Range(900f, 1000f)] private float minDistanceBetweenAsteroids = 900f;
    [SerializeField, Range(1000f, 1100f)] private float maxDistanceBetweenAsteroids = 1000f;

    [Header("Asteroid Speeds")]
    [SerializeField] private float minOrbitSpeed = 10f;
    [SerializeField] private float maxOrbitSpeed = 30f;
    [SerializeField] private float minRotationSpeed = 10f;
    [SerializeField] private float maxRotationSpeed = 50f;

    private IAsteroidSpawner _asteroidSpawner;
    private IObjectPool<GameObject> _asteroidPool;

    private void Awake()
    {
        _asteroidPool = new GameObjectPool(asteroidPrefab, asteroidCount, transform);

        _asteroidSpawner = new AsteroidSpawner(_asteroidPool, earthTransform,
            minOrbitRadius, maxOrbitRadius,
            minOrbitSpeed, maxOrbitSpeed,
            minRotationSpeed, maxRotationSpeed);


        _asteroidSpawner.SpawnAsteroids(asteroidCount, minDistanceBetweenAsteroids, maxDistanceBetweenAsteroids);
    }

    private void Update()
    {
        _asteroidSpawner.UpdateAsteroids();
    }
}