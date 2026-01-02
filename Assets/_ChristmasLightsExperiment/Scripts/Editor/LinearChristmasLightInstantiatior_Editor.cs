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
            lightInstantiatior.StartPoint.SetPositionAndRotation(
                christmasLightCollection.transform.position + Vector3.left,
                Quaternion.identity);
            
            lightInstantiatior.EndPoint.SetPositionAndRotation(
                christmasLightCollection.transform.position +  Vector3.right,
                Quaternion.identity);
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
        var startPoint = lightInstantiatior.StartPoint.position;
        var endPoint = lightInstantiatior.EndPoint.position;
        
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
