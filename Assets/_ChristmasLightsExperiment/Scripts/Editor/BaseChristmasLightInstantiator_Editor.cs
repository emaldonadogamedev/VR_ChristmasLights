using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseChristmasLightInstantiator))]
public abstract class BaseChristmasLightInstantiator_Editor : Editor
{
    protected abstract void GenerateLights();
    
    protected abstract void ClearLights();
}
