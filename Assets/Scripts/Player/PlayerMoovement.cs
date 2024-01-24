using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoovement : MonoBehaviour
{
    private const float gravity = -9.8f;
    [Header("Movement vars")]
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private bool isGrounded;

    [Header("Settings")]
    [SerializeField] private float jumpOffset = 0.15f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundColTransform;
    [SerializeField] private LayerMask groundMask;

    private float offset = -0.7f;
    private float playerScaleX;
    public bool IsFlipRight { get; private set; }
    private Rigidbody2D rigidbody;
    private Animator animator;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        IsFlipRight = true;
        playerScaleX = transform.localScale.x;
        offset = -0.7f;
    }

    private void FixedUpdate()
    {
        Vector2 overlapCirclePosition = groundColTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);


    }

    public void Move(float direction, bool GetJumpButton)
    {
        if (GetJumpButton)
        {
            Jump();
        }
        if (Math.Abs(direction) > 0.01)
        {
            HorizontalMove(direction);
        }
        else
        {
            animator.SetBool("CanRun", false);
        }
    }

    private void HorizontalMove(float direction)
    {
        animator.SetBool("CanRun", true);
        if ( (direction > 0 && IsFlipRight == false ) || (direction < 0 && IsFlipRight == true))
        {
            Flip();
        }

        rigidbody.velocity = new Vector2(curve.Evaluate(direction), rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            animator.SetTrigger("Jump");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    private void Flip()
    {
        IsFlipRight = !IsFlipRight;
        Vector3 localScale = transform.localScale;
        localScale.x = localScale.x * -1;
        transform.localScale = localScale;

        offset *= -1;
        
        Vector3 newtransform = transform.position;
        newtransform.x = transform.position.x + offset;
        transform.position = newtransform;

    }

}
