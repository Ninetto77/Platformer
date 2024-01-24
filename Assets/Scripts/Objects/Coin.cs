using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float Cost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<PlayerController>().GetBonuses(Cost);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
