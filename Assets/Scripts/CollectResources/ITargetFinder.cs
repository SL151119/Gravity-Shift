using UnityEngine;

public interface ITargetFinder
{
    Transform FindNearestResource(Vector3 position, float radius);
}
