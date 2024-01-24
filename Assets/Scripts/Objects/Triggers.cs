using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    [SerializeField] private PlatformMovement platform;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null && collision.gameObject.tag.Equals("Platform"))
        {
            if (platform.IsDown)
            {
                platform.Speed = 1;
            }
            else
            {
                platform.Speed = -1;
            }
            platform.IsDown = !platform.IsDown;
        }
    }
}
