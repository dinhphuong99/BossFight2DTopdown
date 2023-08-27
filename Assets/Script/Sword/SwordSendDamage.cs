using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSendDamage : MonoBehaviour
{
    [SerializeField] private GameObject objectTakeDamage;
    [SerializeField] private float damage = 10f;
    private Life life;
    private LifeWithRevival lifeWithRevival;
    [SerializeField] private bool isSent = true;
    private List<GameObject> damageReceivers = new List<GameObject>();
    private void Start()
    {

    }

    public void SetFalse2IsSent()
    {
        this.isSent = false;
    }

    public void SetTrue2IsSent()
    {
        this.isSent = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectTakeDamage.tag))
        {
            if (!damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Add(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectTakeDamage.tag))
        {
            if (damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectTakeDamage.tag))
        {
            if (!damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTakeDamage.tag))
        {
            if (damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Remove(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (!isSent)
        {
            foreach (GameObject obj in damageReceivers)
            {
                life = obj.GetComponent<Life>();
                lifeWithRevival = obj.GetComponent<LifeWithRevival>();

                if (life != null)
                {
                    life.TakeDamage(damage);
                }
                else if (lifeWithRevival != null)
                {
                    lifeWithRevival.TakeDamage(damage);
                }
            }

            isSent = true;
        }
    }
}