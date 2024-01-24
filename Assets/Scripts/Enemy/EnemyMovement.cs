using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Walk()
    {
        body.velocity = Vector2.right * speed;
    }

    public void ChangeSpeed()
    {
        speed *= -1;
    }

    public float GetSpeedMagnitude()
    {
        return body.velocity.magnitude;
    }
}
