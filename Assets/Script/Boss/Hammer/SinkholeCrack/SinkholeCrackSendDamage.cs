using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkholeCrackSendDamage : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    public float damage = 10f;
    private Life life;
    private PlayerLife playerLife;
    public bool canSend = true;

    // Start is called before the first frame update
    void Start()
    {
        canSend = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && canSend)
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.TakeDamage(damage);
                canSend = false;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                canSend = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && canSend)
        {
            life = collision.gameObject.GetComponent<Life>();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (collision.gameObject.CompareTag(tagTakeDamage) && canSend)
            {
                life = collision.gameObject.GetComponent<Life>();
                playerLife = collision.gameObject.GetComponent<PlayerLife>();

                if (life != null)
                {
                    life.TakeDamage(damage);
                    canSend = false;
                }
                else if (playerLife != null)
                {
                    playerLife.TakeDamage(damage);
                    canSend = false;
                }
            }
        }
    }
}