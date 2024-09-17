using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : IAsteroidSpawner
{
    private readonly GameObject _asteroidPrefab;
    private readonly Transform _earthTransform;
    private readonly float _minOrbitRadius;
    private readonly float _maxOrbitRadius;

    private readonly float _minOrbitSpeed;
    private readonly float _maxOrbitSpeed;
    private readonly float _minRotationSpeed;
    private readonly float _maxRotationSpeed;

    private readonly IObjectPool<GameObject> _asteroidPool;

    private readonly List<IAsteroidMovement> _asteroids = new List<IAsteroidMovement>();

    public AsteroidSpawner(IObjectPool<GameObject> asteroidPool, Transform earthTransform,
        float minOrbitRadius, float maxOrbitRadius,
        float minOrbitSpeed, float maxOrbitSpeed, 
        float minRotationSpeed, float maxRotationSpeed)
    {
        _asteroidPool = asteroidPool;
        _earthTransform = earthTransform;
        _minOrbitRadius = minOrbitRadius;
        _maxOrbitRadius = maxOrbitRadius;

        _minOrbitSpeed = minOrbitSpeed;
        _maxOrbitSpeed = maxOrbitSpeed;
        _minRotationSpeed = minRotationSpeed;
        _maxRotationSpeed = maxRotationSpeed;
    }

    public void SpawnAsteroids(int count, float minDistanceBetweenAsteroids, float maxDistanceBetweenAsteroids)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(minDistanceBetweenAsteroids, maxDistanceBetweenAsteroids);
            GameObject asteroid = _asteroidPool.Get();
            asteroid.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);

            float randomOrbitSpeed = GetRandomOrbitSpeed();
            float randomRotationSpeed = GetRandomRotationSpeed();

            AsteroidMovementService asteroidMovement = new AsteroidMovementService(asteroid.transform, _earthTransform, randomOrbitSpeed, randomRotationSpeed);
            _asteroids.Add(asteroidMovement);
        }
    }

    private Vector3 GetRandomSpawnPosition(float minDistanceBetweenAsteroids, float maxDistanceBetweenAsteroids)
    {
        float angle = Random.Range(0f, 360f); // Imagine orbit as a circle. It's a circle angle to spawn

        // Get a random radius (distance from Earth) within the allowed orbit range
        float radius = Random.Range(_minOrbitRadius, _maxOrbitRadius);

        // Random position in the orbit plane around the Earth
        Vector3 direction = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Vector3 position = _earthTransform.position + direction * radius;

        // Distance between asteroids
        float distanceFromLastAsteroid = Random.Range(minDistanceBetweenAsteroids, maxDistanceBetweenAsteroids);
        position += direction * distanceFromLastAsteroid;

        return position;
    }

    private float GetRandomOrbitSpeed()
    {
        return Random.Range(_minOrbitSpeed, _maxOrbitSpeed);
    }

    private float GetRandomRotationSpeed()
    {
        return Random.Range(_minRotationSpeed, _maxRotationSpeed);
    }

    public void UpdateAsteroids()
    {
        foreach (var asteroid in _asteroids)
        {
            asteroid.OrbitAroundEarth();
            asteroid.RotateAroundAxis();
        }
    }
}
