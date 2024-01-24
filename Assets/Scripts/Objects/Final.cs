using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField]private SpriteRenderer _sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ) 
        {
            _sprite.enabled = true;
            GameManager.Instance.FinishLevel();
        }
    }
}
