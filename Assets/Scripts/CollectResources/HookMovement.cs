using DG.Tweening;
using UnityEngine;

public class HookMovement : IHookMovement
{
    private readonly Transform _hookTransform;
    private readonly Transform _initialHookTransform;

    private readonly LineRenderer _lineRenderer;

    private readonly Vector3 _initialLocalPosition;
    private readonly Quaternion _initialLocalRotation;

    private Transform _target;

    public HookMovement(Transform hookTransform, Transform initialHookTransform, LineRenderer lineRenderer)
    {
        _hookTransform = hookTransform;
        _lineRenderer = lineRenderer;

        _initialLocalPosition = _hookTransform.localPosition;
        _initialLocalRotation = _hookTransform.localRotation;

        _initialHookTransform = initialHookTransform;
    }

    public void MoveToTarget(Transform target)
    {
        _target = target;

        if (_target.TryGetComponent(out Collider targetCollider))
        {
            targetCollider.enabled = false; // Disable the resource collider to prevent collide with ship
        }

        SetPositionsCount(2);

        _hookTransform.DOMove(_target.position, 1f)
           .OnUpdate(() =>
           {
               _hookTransform.LookAt(_target);
               UpdateLineRenderer();
           })
           .OnComplete(() =>
           {
               ReturnToShipWithResource();
           });
    }

    public void ReturnToShipWithResource()
    {
        _target.DOLocalRotateQuaternion(_hookTransform.rotation, 1f);

        _hookTransform.DOLocalMove(_initialLocalPosition, 1f)
            .OnUpdate(() =>
            {
                _hookTransform.LookAt(_target);

                _target.SetParent(_hookTransform); //Make _target a child object of hook to follow it
               
                UpdateLineRenderer();
            })
            .OnComplete(() =>
            {
                _hookTransform.DOLocalRotateQuaternion(_initialLocalRotation, 0f);
                SetPositionsCount(0);

                GameObject.Destroy(_target.gameObject);
                _target = null;
            });

    }

    private void UpdateLineRenderer()
    {
        _lineRenderer.SetPosition(0, _initialHookTransform.position);
        _lineRenderer.SetPosition(1, _hookTransform.position);
    }

    private void SetPositionsCount(int count)
    {
        _lineRenderer.positionCount = count;
    }
}
