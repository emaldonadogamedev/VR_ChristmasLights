using System.Linq;
using UnityEngine;

public class LinearChristmasLightInstantiatior : BaseChristmasLightInstantiator
{
    [SerializeField]
    [HideInInspector]
    private GameObject instantiatorEndpointPrefab;
    
#if UNITY_EDITOR
    private Vector3[] gizmosPositions = 
    {
        new(),
        new(),
        new(),
        new()
    };
#endif
    
    public Vector3 StartPoint
    {
        get
        {
            var knot0 = _splineContainer.Spline.Knots.ElementAt(0); 
            var worldPos = _splineContainer.transform.TransformPoint(knot0.Position);
            
            return worldPos;
        }
    }

    public Vector3 EndPoint
    {
        get
        {
            var knot1 = _splineContainer.Spline.Knots.ElementAt(1); 
            var worldPos = _splineContainer.transform.TransformPoint(knot1.Position);
            
            return worldPos;
        }
    }
    
    protected new void OnEnable()
    {
        Debug.Log("LinearChristmasLightInstantiatior.OnEnable");
        
        base.OnEnable();
    }
    
    private GameObject CreateEndPoint(string endPointName)
    {
        var newEndpoint = Instantiate(instantiatorEndpointPrefab, this.transform);
        newEndpoint.name = endPointName;
        
        return newEndpoint;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var christmasLightCollection = GetComponent<ChristmasLightCollection>();
        
        gizmosPositions[0] = StartPoint;
        gizmosPositions[1] = StartPoint + Vector3.up * .1f;
        gizmosPositions[2] = EndPoint + Vector3.up * .1f;
        gizmosPositions[3] = EndPoint;
        
        
        Gizmos.DrawLineStrip(gizmosPositions, false);
    }
#endif
}