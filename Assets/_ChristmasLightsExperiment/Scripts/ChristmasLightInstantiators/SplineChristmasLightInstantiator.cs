using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(SplineContainer))]
public class SplineChristmasLightInstantiator : BaseChristmasLightInstantiator
{
    [SerializeField]
    [HideInInspector]
    private SplineContainer splineContainer;
    
    [SerializeField]
    private bool useSplineInstantiate = false;
    
    protected new void OnValidate()
    {
        base.OnValidate();
        
        splineContainer = GetComponent<SplineContainer>();
    }
}