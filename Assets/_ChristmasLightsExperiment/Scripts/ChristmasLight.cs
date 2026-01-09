using UnityEngine;

[DisallowMultipleComponent]
public class ChristmasLight : MonoBehaviour
{
    public enum LightType : byte
    {
        Emissive,
        PointLight
    }
    
    [SerializeField]
    private GameObject emissiveLight;
    
    [SerializeField]
    private GameObject pointLight;
    
    public LightType lightType { get; private set; }
    
    private void Start()
    {
        lightType =  LightType.Emissive;
        
        // Quick color "randomizer"
        var randInt = Random.Range(1, 101);
        var color = Color.white;

        if (randInt < 20)
            color = Color.red;
        else if(randInt < 40)
            color = Color.green;
        else if(randInt < 60)
            color = Color.blue;
        else if(randInt < 80)
            color = Color.yellow;
        
        SetColor(color);
    }
    
    public void SwitchLightType(LightType newLightType)
    {
        emissiveLight.SetActive(newLightType == LightType.Emissive);
        pointLight.SetActive(newLightType == LightType.PointLight);
        
        lightType = newLightType;
    }

    public void SetColor(Color color)
    {
        if(emissiveLight.activeSelf)
            emissiveLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", color * 10f);
        
        if(pointLight.activeSelf)
            pointLight.GetComponent<Light>().color = color;
    }
}
