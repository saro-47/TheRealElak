using UnityEngine;

[CreateAssetMenu(menuName = "Terrain System/HeightMap Settings")]
public class HeightMapSettings : UpdatableData
{
    public NoiseSettings noiseSettings;
    
    public float heightMultiplier;
    public AnimationCurve heightCurve;
    
    public bool useFalloff;

    public float minHeight => heightMultiplier * heightCurve.Evaluate (0);
    public float maxHeight => heightMultiplier * heightCurve.Evaluate (1);

#if UNITY_EDITOR
    
    private protected override void OnValidate()
    {
        noiseSettings.ValidateValues();
        base.OnValidate();
    }
#endif
}
