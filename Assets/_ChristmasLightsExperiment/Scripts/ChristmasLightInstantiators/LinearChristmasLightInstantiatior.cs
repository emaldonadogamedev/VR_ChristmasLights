using System;
using System.Collections.Generic;
using UnityEngine;

public class LinearChristmasLightInstantiatior : BaseChristmasLightInstantiator
{
    [SerializeField]
    [HideInInspector]
    private GameObject instantiatorEndpointPrefab;
    
#if UNITY_EDITOR
    
    Vector3[] gizmosPositions = 
    {
        new(),
        new(),
        new(),
        new()
    };
#endif
    
    public Transform StartPoint
    {
        get 
        { 
            if (startPointObject == null)
            {
                startPointObject = CreateEndPoint("StartPoint");
            }
                
            return startPointObject.transform; 
        }
    }

    public Transform EndPoint
    {
        get
        {
            if (endPointObject == null)
            {
                endPointObject = CreateEndPoint("EndPoint");
            }
            return endPointObject.transform;
        }
    }

    private GameObject startPointObject;
    private GameObject endPointObject;
    
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
        
        gizmosPositions[0] = StartPoint.position;
        gizmosPositions[1] = StartPoint.position + Vector3.up * .1f;
        gizmosPositions[2] = EndPoint.position + Vector3.up * .1f;
        gizmosPositions[3] = EndPoint.position;
        
        
        Gizmos.DrawLineStrip(gizmosPositions, false);
    }
#endif
}