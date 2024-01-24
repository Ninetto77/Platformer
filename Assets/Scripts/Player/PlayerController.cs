using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Health playerHealth;
    private Animator animator;
    private float bonuses = 0;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ( !playerHealth.isAlive) 
        {
            animator.SetTrigger("Die");
            GameManager.Instance.LooseGame();
        }

        GameManager.Instance.SetSliderValue(playerHealth.GetCurrentHealth());
    }

    public void KillPlayer()
    {
        playerHealth.TakeDamage(100f);
    }

    public void GetBonuses(float value)
    {
        bonuses += value;
        GameManager.Instance.SetBonusValue(bonuses);
    }
}
