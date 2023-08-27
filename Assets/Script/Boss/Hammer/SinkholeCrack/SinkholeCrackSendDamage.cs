using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SinkholeCrackSendDamage : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    [SerializeField] private float damage = 10f;
    private Life life;
    private LifeWithRevival lifeWithRevival;
    [SerializeField] private bool isSent = false;
    private List<GameObject> damageReceivers = new List<GameObject>();
    [SerializeField] private float sendTime = 4f;
    private float sendTimer = 0f;

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
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            if (!damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Add(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            if (damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            if (!damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagTakeDamage))
        {
            if (damageReceivers.Contains(collision.gameObject))
            {
                damageReceivers.Remove(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        sendTimer += Time.unscaledDeltaTime;
        if (sendTimer >= sendTime)
        {
            isSent = true;
        }

        if (!isSent && damageReceivers.Any())
        {
            List<GameObject> objectsToRemove = new List<GameObject>(); // Danh sách tạm thời

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

                objectsToRemove.Add(obj); // Thêm vào danh sách tạm thời
            }

            foreach (GameObject obj in objectsToRemove)
            {
                damageReceivers.Remove(obj); // Loại bỏ khỏi danh sách chính
            }
        }
    }
}