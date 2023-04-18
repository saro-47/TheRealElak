using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    private Avatar avatar;
    private Component animator;
    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf && child.gameObject.tag.Equals("Avatar"))
            {
                avatar = child.GetComponent<Animator>().avatar;
                break;
            }
        }

        gameObject.GetComponent<Animator>().avatar = avatar;
    }
}
