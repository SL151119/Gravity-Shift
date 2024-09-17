using UnityEngine;

public class ShipResourceCollector : MonoBehaviour
{
    [Header("Hook")]
    [SerializeField] private Transform hookTransform;
    [SerializeField] private Transform initialHookTransform;

    [Header("Resource Finder")]
    [SerializeField] private Transform resourceFinderArea;
    [SerializeField, Range(3f, 5f)] private float collectionInterval = 3f;

    [Space]
    [SerializeField] private LineRenderer lineRenderer;

    private readonly float resourceFinderRadius = 30f;

    private float _timeSinceLastCollection = 0f;

    private IResourceCollector _resourceCollector;

    private void Awake()
    {
        ITargetFinder targetFinder = new TargetFinder(transform);
        IHookMovement hookMovement = new HookMovement(hookTransform, initialHookTransform, lineRenderer);

        _resourceCollector = new ResourceCollector(targetFinder, hookMovement, resourceFinderArea, resourceFinderRadius);
    }

    private void Update()
    {
        _timeSinceLastCollection += Time.deltaTime;

        if (_timeSinceLastCollection >= collectionInterval)
        {
            _resourceCollector.CollectResources();
            _timeSinceLastCollection = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(resourceFinderArea.position, resourceFinderRadius);
    }
}
