using UnityEngine;

public class ResourceCollector : IResourceCollector
{
    private readonly ITargetFinder _targetFinder;
    private readonly IHookMovement _hookMovement;
    private readonly Transform _resourceFinderArea;
    private readonly float _resourceFinderRadius;

    public ResourceCollector(ITargetFinder targetFinder, IHookMovement hookMovement, Transform resourceFinderArea, float resourceFinderRadius)
    {
        _targetFinder = targetFinder;
        _hookMovement = hookMovement;
        _resourceFinderArea = resourceFinderArea;
        _resourceFinderRadius = resourceFinderRadius;
    }

    public void CollectResources()
    {
        Transform nearestResource = _targetFinder.FindNearestResource(_resourceFinderArea.position, _resourceFinderRadius);

        if (nearestResource != null)
        {
            _hookMovement.MoveToTarget(nearestResource);
        }
    }
}
