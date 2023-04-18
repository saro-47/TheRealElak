using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour
{
    
    [Tooltip("Camera used to take screenshot."), SerializeField] 
    private Camera screenShotCamera;

    [Tooltip("Path used to save screenshot."), SerializeField]
    private string screenShotSavePath;
    
    public void TakeScreenshot()
    {
        if (screenShotCamera == null)
        {
            screenShotCamera = FindObjectOfType<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        screenShotCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        screenShotCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        screenShotCamera.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/Icons/" + screenShotSavePath, bytes);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
