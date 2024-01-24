using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

}
