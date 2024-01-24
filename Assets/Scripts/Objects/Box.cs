using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject BurnColliderPrefab;
    public float timeToDestroy = 0.1f;

    private GameObject burnCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Arrow"))
        {
            burnCollider = Instantiate(BurnColliderPrefab, transform);
            Destroy(this.gameObject.transform.parent.gameObject , timeToDestroy);
        }
    }
}
