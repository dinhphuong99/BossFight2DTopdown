using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    [SerializeField] private float damage = 10f;
    private Life life;
    private LifeWithRevival playerLife;
    private bool isSent = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && !isSent)
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<LifeWithRevival>();

            if (life != null)
            {
                life.TakeDamage(damage);
                isSent = true;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                isSent = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && !isSent)
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<LifeWithRevival>();

            if (life != null)
            {
                life.TakeDamage(damage);
                isSent = true;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                isSent = true;
            }
        }
    }

}
