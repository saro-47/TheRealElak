using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Terrain System/Mesh Settings")]
public class MeshSettings : UpdatableData
{
    public const int numSupportedLODs = 5;
    public const int numSupportedChunkSizes = 9;
    public const int numSupportedFlatShadedChunkSizes = 3;
    public static readonly int[] supportedChunkSizes = {48, 72, 96, 120, 144, 168, 192, 216, 240};
    
    public float meshScale = 2f;
    public bool useFlatShading;
    
    
    [Range(0, numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;
    [Range(0, numSupportedFlatShadedChunkSizes - 1)]
    public int flatShadedChunkSizeIndex;
    
    
    //For LOD = 0. Includes 2 extra vertices which are excluded from final mesh, but used for normals calculation
    public int numVertsPerLine => supportedChunkSizes[useFlatShading ? flatShadedChunkSizeIndex : chunkSizeIndex] + 5;

    public float meshWorldSize => (numVertsPerLine - 3) * meshScale;
}
