using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private SliderJoint2D joint;
    public bool IsDown {  get; set; }
    public float Speed { private get; set; }
    private JointMotor2D motor;
    void Start()
    {
        joint = gameObject.GetComponent<SliderJoint2D>();
        joint.useMotor = true;
        IsDown = true;
        Speed = -1;

    }

    void Update()
    {
        motor = joint.motor;
        motor.motorSpeed = Speed;
        joint.motor = motor;
    }

}
