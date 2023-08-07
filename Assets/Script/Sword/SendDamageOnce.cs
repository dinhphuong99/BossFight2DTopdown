using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamageOnce : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    [SerializeField] private float damage = 10f;
    private Life life;
    private PlayerLife playerLife;
    private bool isSent = true;

    // Start is called before the first frame update
    void Start()
    {
        this.isSent = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            Debug.Log("isT = " + true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && !this.isSent)
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.TakeDamage(damage);
                this.isSent = true;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                this.isSent = true;
            }
        }
    }

    
}
