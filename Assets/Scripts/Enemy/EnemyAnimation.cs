using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Walk(float speed)
    {
        animator.SetFloat("Velocity", speed);
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }
}
