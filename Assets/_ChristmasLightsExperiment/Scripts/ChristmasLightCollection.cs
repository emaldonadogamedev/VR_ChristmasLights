using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class ChristmasLightCollection : MonoBehaviour
{
    public enum ChristmasLightType
    {
        Emissive,
        PointLight_Basked
    }
    
    [SerializeField]
    [HideInInspector]
    private GameObject lightPrefab;
    
    [Header("Light Settings")]
    [SerializeField]
    [Range(1, 200)]
    private int numberOfLights;

    [SerializeField]
    private bool bakedLighting = false;

    public int NumberOfLights => numberOfLights;
    public GameObject LightPrefab => lightPrefab;
    
    [HideInInspector]
    public List<GameObject> lightsScattered;

    private void Awake()
    {
        lightsScattered = new List<GameObject>();
    }
}
