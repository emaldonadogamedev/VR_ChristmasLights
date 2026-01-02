using UnityEngine;

static public class ChristmasLightContainerObjectCreator
{
    public static GameObject CreateLightContainerObject(ChristmasLightCollection christmasLightCollection)
    {
        var lightContainer = new GameObject("LightContainer");
        
        lightContainer.transform.SetPositionAndRotation(
            christmasLightCollection.transform.position,
            christmasLightCollection.transform.rotation);
        
        lightContainer.transform.SetParent(christmasLightCollection.transform);
        
        return lightContainer;
    }
}
