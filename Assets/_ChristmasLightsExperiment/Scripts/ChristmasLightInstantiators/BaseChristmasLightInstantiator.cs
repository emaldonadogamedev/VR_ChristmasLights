using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ChristmasLightCollection))]
public abstract class BaseChristmasLightInstantiator : MonoBehaviour
{
    [SerializeField]
    private ChristmasLightCollection.ChristmasLightType christmasLightType = 
        ChristmasLightCollection.ChristmasLightType.Emissive;
    
    protected ChristmasLightCollection christmasLightCollection;
    
    public GameObject LightContainerObject
    {
        get
        {
            if (lightContainerObject == null)
            {
                var christmasLightCollection = GetComponent<ChristmasLightCollection>();
                lightContainerObject = 
                    ChristmasLightContainerObjectCreator.CreateLightContainerObject(christmasLightCollection);
            }

            return lightContainerObject;   
        }
    }

    private GameObject lightContainerObject = null;
    
    public void AddNewLight(Vector3 scatterPosition)
    {
        GameObject newChristmasLight = ChristmasLightCreator.CreateNewChristmasLight(
            christmasLightCollection.LightPrefab, 
            scatterPosition,
            LightContainerObject);
            
        christmasLightCollection.lightsScattered.Add(newChristmasLight);
    }

    public void RemoveAllLights()
    {
        ChristmasLightRemover.ClearLightsFromCollection(christmasLightCollection);
    }

    protected void OnValidate()
    {
        christmasLightCollection = GetComponent<ChristmasLightCollection>();
    }
}