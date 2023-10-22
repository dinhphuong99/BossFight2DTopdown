using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SinkholeCrackSendDamage : SendDamageMultipleTarget
{
    [SerializeField] private float sendTime = 1.2f;
    private float sendTimer = 0f;

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            sendTimer += Time.unscaledDeltaTime;
        }
        
        if (sendTimer >= sendTime)
        {
            isSent = true;
            ListIdSentDamage.Clear();
        }
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && !isSent)
        {

            foreach (int id in ListIdSentDamage)
            {
                if (id == collision.gameObject.GetInstanceID())
                {
                    return;
                }
            }

            ListIdSentDamage.Add(collision.gameObject.GetInstanceID());
            life = collision.gameObject.GetComponent<Life>();
            lifeWithRevival = collision.gameObject.GetComponent<LifeWithRevival>();

            if (life != null)
            {
                life.TakeDamage(damage);
            }
            else if (lifeWithRevival != null)
            {
                lifeWithRevival.TakeDamage(damage);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && !isSent)
        {
            foreach (int id in ListIdSentDamage)
            {
                if (id == collision.gameObject.GetInstanceID())
                {
                    return;
                }
            }

            ListIdSentDamage.Add(collision.gameObject.GetInstanceID());
            life = collision.gameObject.GetComponent<Life>();
            lifeWithRevival = collision.gameObject.GetComponent<LifeWithRevival>();

            if (life != null)
            {
                life.TakeDamage(damage);
            }
            else if (lifeWithRevival != null)
            {
                lifeWithRevival.TakeDamage(damage);
            }
        }
    }
}
