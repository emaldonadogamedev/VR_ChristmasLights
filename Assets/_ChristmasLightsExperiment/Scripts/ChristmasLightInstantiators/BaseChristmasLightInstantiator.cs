using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

[DisallowMultipleComponent]
[RequireComponent(
    typeof(ChristmasLightCollection),
    typeof(SplineContainer), 
    typeof(SplineInstantiate))]
[RequireComponent(typeof(LineRenderer))]
public abstract class BaseChristmasLightInstantiator : MonoBehaviour
{
    [SerializeField]
    private ChristmasLightCollection.ChristmasLightType christmasLightType = 
        ChristmasLightCollection.ChristmasLightType.Emissive;
    
    protected ChristmasLightCollection _christmasLightCollection;
    protected SplineContainer _splineContainer;
    protected SplineInstantiate _splineInstantiate;
    protected LineRenderer _lineRenderer;
    
    public void AddNewLight(Vector3 scatterPosition)
    {
        foreach (Transform child in _splineInstantiate.transform.GetChild(0).transform)
        {
            print("Instantiated Object: " + child.name);
        }
    }

    public void RemoveAllLights()
    {
        _splineInstantiate.Clear();
    }

    protected void OnEnable()
    {
        Debug.Log("BaseChristmasLightInstantiator.OnEnable");
        
        _christmasLightCollection = GetComponent<ChristmasLightCollection>();
        
        _splineContainer = GetComponent<SplineContainer>();
        if (_splineContainer.Spline.Knots.Count() < 2)
        {
            while (_splineContainer.Spline.Knots.Count() < 2)
            {
                _splineContainer.Spline.Add(Vector3.zero, TangentMode.Linear);
            }
        }
        
        _splineInstantiate = GetComponent<SplineInstantiate>();
        _splineInstantiate.InstantiateMethod = SplineInstantiate.Method.InstanceCount;
        
        _lineRenderer = GetComponent<LineRenderer>();
        
        #if UNITY_EDITOR
        _splineContainer.hideFlags = HideFlags.NotEditable;
        _splineInstantiate.hideFlags = HideFlags.NotEditable;
        _lineRenderer.hideFlags = HideFlags.NotEditable;
        #endif
    }
}