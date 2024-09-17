using UnityEngine;

public class TargetFinder : ITargetFinder
{
    private readonly Transform _shipTransform;

    public TargetFinder(Transform shipTransform)
    {
        _shipTransform = shipTransform;
    }

    public Transform FindNearestResource(Vector3 position, float radius)
    {
        Collider[] targets = Physics.OverlapSphere(position, radius);

        Transform nearestResource = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider target in targets)
        {
            if (target.TryGetComponent(out Resource _))
            {
                //We're using shipTransform here instead of resourceFinderArea
                //to take the resources closest to the ship.
                //Otherwise, the resources closest to the center of the aura
                //will be taken first

                float distance = Vector3.Distance(target.transform.position, _shipTransform.position); 
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestResource = target.transform;
                }
            }
        }

        return nearestResource;
    }
}
