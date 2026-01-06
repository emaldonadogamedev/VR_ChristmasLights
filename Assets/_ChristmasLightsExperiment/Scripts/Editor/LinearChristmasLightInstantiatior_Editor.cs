using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LinearChristmasLightInstantiatior))]
public class LinearChristmasLightInstantiatior_Editor : BaseChristmasLightInstantiator_Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        var christmasLightCollection = 
            Selection.activeGameObject.GetComponent<ChristmasLightCollection>();
        
        var lightInstantiatior = 
            christmasLightCollection.GetComponent<LinearChristmasLightInstantiatior>();
        
        if (GUILayout.Button("Reset Endpoints"))
        {
            
        }
        if (GUILayout.Button("Scatter Lights"))
        {
            GenerateLights();
        }

        if (GUILayout.Button("Clear Lights"))
        {
            ClearLights();
        }
    }
    
    override protected void GenerateLights()
    {
        ClearLights();
        
        var christmasLightCollection = Selection.activeGameObject.GetComponent<ChristmasLightCollection>();

        var lightInstantiatior = 
            christmasLightCollection.GetComponent<LinearChristmasLightInstantiatior>();
        
        int numberOfLights = christmasLightCollection.NumberOfLights;
        var startPoint = lightInstantiatior.StartPoint;
        var endPoint = lightInstantiatior.EndPoint;
        
        if (numberOfLights <= 1)
        {
            var scatterPosition = Vector3.Lerp(startPoint, endPoint, .5f);
            
            lightInstantiatior.AddNewLight(scatterPosition);
        }
        
        for(int i = 0; i < numberOfLights; i++)
        {
            float t = (float)i / (numberOfLights-1);
            var scatterPosition = Vector3.Lerp(startPoint, endPoint, t);

            lightInstantiatior.AddNewLight(scatterPosition);
        }
    }
    
    override protected void ClearLights()
    {
        var lightInstantiatior = 
            Selection.activeGameObject.GetComponent<LinearChristmasLightInstantiatior>();
        
        lightInstantiatior.RemoveAllLights();
    }
}
