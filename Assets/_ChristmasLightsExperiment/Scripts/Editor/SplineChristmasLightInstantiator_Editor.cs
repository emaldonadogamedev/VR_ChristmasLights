using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

[CustomEditor(typeof(SplineChristmasLightInstantiator))]
public class SplineChristmasLightInstantiator_Editor : BaseChristmasLightInstantiator_Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.Space();
        
        if (GUILayout.Button("Scatter Lights"))
        {
            GenerateLights();
        }
        
        if (GUILayout.Button("Clear Lights"))
        {
            ClearLights();
        }
    }

    protected override void GenerateLights()
    {
        ClearLights();
        
        var splineContainer = Selection.activeGameObject.GetComponent<SplineContainer>();

        if (splineContainer.Spline.Count < 1)
        {
            Debug.LogError("Spline container is empty, cannot create lights");
            return;   
        }
        
        var christmasLightCollection = Selection.activeGameObject.GetComponent<ChristmasLightCollection>();

        var lightInstantiatior = 
            christmasLightCollection.GetComponent<SplineChristmasLightInstantiator>();
        
        int numberOfLights = christmasLightCollection.NumberOfLights;
        
        if (numberOfLights < 2)
        {
            var scatterPosition = splineContainer.EvaluatePosition(.5f);
            lightInstantiatior.AddNewLight(scatterPosition);
        }
        
        for(int i = 0; i < numberOfLights; i++)
        {
            float t = (float)i / (numberOfLights-1);
            var scatterPosition = splineContainer.EvaluatePosition(t);
            
            lightInstantiatior.AddNewLight(scatterPosition);
        }
    }

    protected override void ClearLights()
    {
        var lightInstantiatior = 
            Selection.activeGameObject.GetComponent<SplineChristmasLightInstantiator>();
        
        lightInstantiatior.RemoveAllLights();
    }
}