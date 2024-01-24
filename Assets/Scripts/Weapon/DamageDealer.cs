using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log(gameObject.name + " MEET " + collision.name);

        if (collision.CompareTag("Damageable") || collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }

        //if (this.gameObject.GetComponent<Health>() != null)
        //{
        //    Health health = this.gameObject.GetComponent<Health>();
        //    if (health.isAlive)
        //    {
        //        return;
        //    }
        //}



        if (collision.CompareTag("Stopper") == false) /*|| collision.CompareTag("BorderCamera") == false)*/
        {
            Destroy(this.gameObject);
        }
    }
}
