using System;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

[RequireComponent(
    typeof(SplineContainer), 
    typeof(SplineInstantiate),
    typeof(LineRenderer))]
[DisallowMultipleComponent]
public class RealtimeLightInstantiator : MonoBehaviour
{

    private bool _isAddingKnots = false;
    private SplineContainer _splineContainer;
    private SplineInstantiate _splineInstantiate;
    private LineRenderer _lineRenderer;
    private Ray _ray = new();

    private void Start()
    {
        _splineContainer = GetComponent<SplineContainer>();
        _splineInstantiate = GetComponent<SplineInstantiate>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            _isAddingKnots = !_isAddingKnots;
            return;
        }
        
        if (!_isAddingKnots)
            return;
        
        // Check if the left mouse button is pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left mouse button clicked!");

            if (!Physics.Raycast(_ray, out RaycastHit hit))
            {
                Debug.Log("Raycast didn't hit");
            }

            Debug.Log($"Raycast hit at point: {hit.point}");
            AddNewKnot(hit.point);
        }
    }

    public void AddNewKnot(Vector3 knotPosition)
    {
        // Get the first spline (most cases only use one)
        var spline = _splineContainer.Spline;

        // Convert world space to local space
        var localPos = _splineContainer.transform.InverseTransformPoint(knotPosition);

        // Create a knot
        var knot = new BezierKnot(localPos);
        
        // Add it to the spline
        spline.Add(knot, TangentMode.Linear);
    }
}
