using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordSendDamage : SendDamageMultipleTarget
{
    private List<GameObjectCanSent> ListObjectSentDamage = new List<GameObjectCanSent>();

    class GameObjectCanSent
    {
        public GameObject obj;
        public bool isSent;
    }

    private void Start()
    {
        this.isSent = true;
        ListObjectSentDamage.Clear();
    }

    public void SetFalse2IsSent()
    {
        this.isSent = false;
    }

    public void SetTrue2IsSent()
    {
        this.isSent = true;
        for (int i = 0; i < ListObjectSentDamage.Count; i++)
        {
            ListObjectSentDamage[i].isSent = false;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            if (!(CheckObjectInList(collision.gameObject) > -1))
            {
                GameObjectCanSent gameObjectCanSent = new GameObjectCanSent();
                gameObjectCanSent.obj = collision.gameObject;
                gameObjectCanSent.isSent = false;

                ListObjectSentDamage.Add(gameObjectCanSent);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            if (!(CheckObjectInList(collision.gameObject) > -1))
            {
                GameObjectCanSent gameObjectCanSent = new GameObjectCanSent();
                gameObjectCanSent.obj = collision.gameObject;
                gameObjectCanSent.isSent = false;

                ListObjectSentDamage.Add(gameObjectCanSent);
            }
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && isSent)
        {
            if (CheckObjectInList(collision.gameObject) > -1)
            {
                ListObjectSentDamage.RemoveAt(CheckObjectInList(collision.gameObject));
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && isSent)
        {
            if (CheckObjectInList(collision.gameObject) > -1)
            {
                ListObjectSentDamage.RemoveAt(CheckObjectInList(collision.gameObject));
            }
        }
    }

    private void Update()
    {

        if (!isSent)
        {
            foreach (GameObjectCanSent gameObject in ListObjectSentDamage)
            {
                SendDamage(gameObject);
            }
        }
    }

    private void SendDamage(GameObjectCanSent gameObjectCanSent)
    {
        if (!gameObjectCanSent.isSent)
        {
            life = gameObjectCanSent.obj.GetComponent<Life>();
            lifeWithRevival = gameObjectCanSent.obj.GetComponent<LifeWithRevival>();

            if (life != null)
            {
                life.TakeDamage(damage);
                gameObjectCanSent.isSent = true;
            }
            else if (lifeWithRevival != null)
            {
                lifeWithRevival.TakeDamage(damage);
                gameObjectCanSent.isSent = true;
            }
        }
        
    }

    private int CheckObjectInList(GameObject obj)
    {
        for (int i = 0; i < ListObjectSentDamage.Count; i++)
        {
            if(ListObjectSentDamage[i].obj.GetInstanceID() == obj.GetInstanceID())
            {
                return i;
            }
        }

        return -1;
    }
}