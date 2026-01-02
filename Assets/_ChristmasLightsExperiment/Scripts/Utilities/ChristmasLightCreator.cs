using UnityEngine;

public static class ChristmasLightCreator
{
    public static GameObject CreateNewChristmasLight(GameObject lightPrefab, Vector3 scatterPosition, GameObject container)
    {
        var newChristmasLight = GameObject.Instantiate(
            lightPrefab,
            scatterPosition,
            Quaternion.identity,
            container.transform);
        
        newChristmasLight.transform.position = scatterPosition;
        
        return newChristmasLight;
    }
}