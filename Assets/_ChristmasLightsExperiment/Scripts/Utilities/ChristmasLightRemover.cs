using UnityEngine;

public static class ChristmasLightRemover
{
    public static void ClearLightsFromCollection(ChristmasLightCollection  christmasLightCollection)
    {
        var lightsScattered = christmasLightCollection.lightsScattered;

        foreach (var lightObj in lightsScattered)
        {
            if(Application.isEditor)
                Object.DestroyImmediate(lightObj);
            else
                Object.Destroy(lightObj);
        }
        
        lightsScattered.Clear();
    }
}
