using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BaseChristmasLightInstantiator))]
public class ChristmasLightRandomColorSetter : MonoBehaviour
{
    [SerializeField]
    public List<Color> colors;

    private void Start()
    {
        ApplyColors();
    }

    private void ApplyColors()
    {
        var christmasLights = gameObject.GetComponentsInChildren<ChristmasLight>(true);

        Debug.Log($"Lights found {christmasLights.Length}, and {colors.Count} available!");
            
        foreach (var christmasLight in  christmasLights)
        {
            var color = colors[Random.Range(0, colors.Count)];
                
            christmasLight.SetColor(color);
        }
    }
}
