using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(
    typeof(SplineContainer), 
    typeof(SplineInstantiate),
    typeof(LineRenderer))]
[DisallowMultipleComponent]
public class RealtimeLightInstantiator : MonoBehaviour
{
    private SplineContainer _splineContainer;
    private SplineInstantiate _splineInstantiate;
    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        _splineContainer = GetComponent<SplineContainer>();
        _splineInstantiate = GetComponent<SplineInstantiate>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    public void AddNewKnot(Transform newKnotPosition)
    {
        // Get the first spline (most cases only use one)
        var spline = _splineContainer.Spline;

        // Convert world space to local space
        var localPos = transform.InverseTransformPoint(newKnotPosition.position);
        
        // Add it to the spline
        spline.Add(localPos, TangentMode.AutoSmooth);
    }
}
