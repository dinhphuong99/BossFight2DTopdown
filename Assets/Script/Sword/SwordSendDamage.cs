using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordSendDamage : SendDamageMultipleTarget
{
    bool shouldAddToList = true; // Biến cờ mặc định là true
    bool findInList = false; // Biến cờ mặc định là false
    private List<GameObject> ListUnsentDamage = new List<GameObject>();
    private void Start()
    {
        this.isSent = true;
        //ListUnsentDamage.Clear();
        ListIdSentDamage.Clear();
    }

    public void SetFalse2IsSent()
    {
        this.isSent = false;
    }

    public void SetTrue2IsSent()
    {
        this.isSent = true;
        //ListUnsentDamage.Clear();
        ListIdSentDamage.Clear();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            foreach (GameObject gameObject in ListUnsentDamage)
            {
                if (gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())
                {
                    shouldAddToList = false; // Nếu có trùng Instant ID, đặt biến cờ thành false và thoát khỏi vòng lặp
                    break;
                }
            }

            if (shouldAddToList)
            {
                ListUnsentDamage.Add(collision.gameObject);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            foreach (GameObject gameObject in ListUnsentDamage)
            {
                if (gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())
                {
                    shouldAddToList = false; // Nếu có trùng Instant ID, đặt biến cờ thành false và thoát khỏi vòng lặp
                    break;
                }
            }

            if (shouldAddToList)
            {
                ListUnsentDamage.Add(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && isSent)
        {
            foreach (GameObject gameObject in ListUnsentDamage)
            {
                if (gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())
                {
                    ListUnsentDamage.Remove(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && isSent)
        {
            foreach (GameObject gameObject in ListUnsentDamage)
            {
                if (gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())
                {
                    ListUnsentDamage.Remove(gameObject);
                    break;
                }
            }
        }
    }

    private void Update()
    {

        if (!isSent)
        {

            foreach (GameObject gameObject in ListUnsentDamage)
            {
                findInList = false;

                foreach (int id in ListIdSentDamage)
                {
                    if (id == gameObject.GetInstanceID())
                    {
                        findInList = true;
                        break;
                    }
                }

                if (!findInList)
                {
                    life = gameObject.GetComponent<Life>();
                    lifeWithRevival = gameObject.GetComponent<LifeWithRevival>();
                    
                    if (life != null)
                    {
                        life.TakeDamage(damage);
                    }
                    else if (lifeWithRevival != null)
                    {
                        lifeWithRevival.TakeDamage(damage);
                    }
                    ListIdSentDamage.Add(gameObject.GetInstanceID());
                }
            }
        }
    }
}