using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenImageXScaler : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private LeanTweenType easeType; 
    [SerializeField] private float scale;
    
    private void OnEnable()
    {
        LeanTween.scaleX(gameObject, scale, duration).setEase(easeType).setLoopPingPong();
    }
}
