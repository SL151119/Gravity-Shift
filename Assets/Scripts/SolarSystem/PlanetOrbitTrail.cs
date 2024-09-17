using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlanetOrbitTrail : MonoBehaviour
{
    [SerializeField] private int maxPositions = 500;
    [SerializeField] private float positionRecordInterval = 0.1f;
    [SerializeField] private float lineRendererWidth = 10f;

    [Header("Line")]
    [SerializeField] private Material _lineMaterial;
    [SerializeField] private LineRenderer _lineRenderer;

    private List<Vector3> _positions;
    private float _timeSinceLastRecord;

    private void Start()
    {
        _positions = new List<Vector3>();
        _timeSinceLastRecord = 0f;

        _lineRenderer.material = _lineMaterial;

        _lineRenderer.positionCount = 0;
        _lineRenderer.startWidth = lineRendererWidth;
        _lineRenderer.endWidth = lineRendererWidth;
    }

    private void Update()
    {
        _timeSinceLastRecord = _timeSinceLastRecord + Time.deltaTime;

        if (_timeSinceLastRecord >= positionRecordInterval)
        {
            RecordPosition();
            _timeSinceLastRecord = 0f;
        }

        _lineRenderer.positionCount = _positions.Count;
        _lineRenderer.SetPositions(_positions.ToArray());
    }

    private void RecordPosition()
    {
        _positions.Add(transform.position);

        // Remove old positions if we exceed the max number of positions
        if (_positions.Count > maxPositions)
        {
            _positions.RemoveAt(0);
        }
    }
}
