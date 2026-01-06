using UnityEngine;

#if UNITY_EDITOR
public class ChristmasLightCollection_EndPoint : MonoBehaviour
{
    private static readonly Vector3 k_EndPointGizmoSize = Vector3.one * .1f; 
    
    private void OnDrawGizmos()
    {
        var christmasLightCollection = GetComponentInParent<ChristmasLightCollection>();
        if (christmasLightCollection == null)
            return;
        
        var lightInstantiatior = christmasLightCollection.GetComponentInChildren<LinearChristmasLightInstantiatior>();
        if (lightInstantiatior == null)
            return;
        
        Gizmos.DrawWireCube(lightInstantiatior.StartPoint, k_EndPointGizmoSize);
        Gizmos.DrawWireCube(lightInstantiatior.EndPoint, k_EndPointGizmoSize);
    }
}
#endif
