using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    [SerializeField] private float damage = 10f;
    private Life life;
    private PlayerLife playerLife;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.TakeDamage(damage);
            }else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.TakeDamage(damage);
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
        }
    }

}
