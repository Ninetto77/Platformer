using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float timeToRevert;
    [SerializeField] private float damage;
    [Tooltip("Через сколько секунд враг погибнет")]
    [SerializeField] private float timeToDestroy = 0.6f;
    private SpriteRenderer sprite;
    private enum StateEnemy
    {
        Idle,
        Walk,
        Revert
    }

    private float curTimeToRevert;
    private StateEnemy curStateEnemy;
    private Health enemyHealth;
    private EnemyMovement enemyMove;
    private EnemyAnimation animator;

    void Start()
    {
        curStateEnemy = StateEnemy.Walk;
        curTimeToRevert = 0;

        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<EnemyAnimation>();
        enemyHealth = GetComponent<Health>();
        enemyMove = GetComponentInChildren<EnemyMovement>();

    }

    void Update()
    {
        if (curTimeToRevert >= timeToRevert)
        {
            curTimeToRevert = 0;
            curStateEnemy = StateEnemy.Revert;
        }

        switch (curStateEnemy)
        {
            case StateEnemy.Idle:
                Idle();
                break;
            case StateEnemy.Walk:
                Walk();
                break;
            case StateEnemy.Revert:
                Revert();
                break;
        }

        animator.Walk(enemyMove.GetSpeedMagnitude());

        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (!enemyHealth.isAlive)
        {
            animator.Death();
            StartCoroutine(WaitForDead());
        }
    }

    private IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(timeToDestroy);
        GameManager.CountDeadEnemy++;
        Destroy(gameObject);
    }

    private void Idle()
    {
        curTimeToRevert += Time.deltaTime;
    }

    private void Walk()
    {
        enemyMove.Walk();
    }

    private void Revert()
    {
        sprite.flipX = !sprite.flipX;
        enemyMove.ChangeSpeed();
        curStateEnemy = StateEnemy.Walk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            curStateEnemy = StateEnemy.Idle;
        }

        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
}
