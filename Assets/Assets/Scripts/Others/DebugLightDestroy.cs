using UnityEngine;

public class DebugLightDestroy : MonoBehaviour
{
    [SerializeField] private GameObject light;
    private void Awake()
    {
        Destroy(light);
    }
}
