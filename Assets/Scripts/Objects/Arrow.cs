using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float timeToDestroy = 0.5f;
    void Start()
    {
        Destroy(gameObject.GetComponent<TargetJoint2D>(), timeToDestroy);
    }


}
