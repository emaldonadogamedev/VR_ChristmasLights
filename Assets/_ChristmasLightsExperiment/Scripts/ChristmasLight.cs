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
            emissiveLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", color * 4f);
        
        if(pointLight.activeSelf)
            pointLight.GetComponent<Light>().color = color;
    }
}
