using System.Collections.Generic;
using UnityEngine;

public class RuntimeChristmasLightsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _christmasLightContainerPrefab;

    public GameObject _currentChristmasLightCollection { get; private set; }
    
    public List<GameObject> _christmasLightCollections { get; private set; } = new();
    
    public void CreateNewChristmasLightCollection()
    {
        _currentChristmasLightCollection = 
            Instantiate(_christmasLightContainerPrefab, Vector3.zero, Quaternion.identity);
        
        _christmasLightCollections.Add(_currentChristmasLightCollection);
    }
    
    public void AddNewKnot(Transform newKnotPosition)
    {
        _currentChristmasLightCollection.GetComponent<RealtimeLightInstantiator>()
            .AddNewKnot(newKnotPosition);
    }
}
