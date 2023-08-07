using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkholeSendDamage : MonoBehaviour
{
    [SerializeField] private float damage = 15f;
    private Life life;
    private PlayerLife playerLife;
    [SerializeField] private GameObject GameObjectTakeDamage;
    [SerializeField] private GameObject hammer;
    private bool isTouchHammerCollider = false;
    private bool isEnabled = false;
    private bool isSendDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        life = GameObjectTakeDamage.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        isEnabled = hammer.GetComponent<PolygonCollider2D>().isActiveAndEnabled;
        isTouchHammerCollider = hammer.GetComponent<DetectionCollider>().isTouch;

        if (!isEnabled)
        {
            isSendDamaged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTakeDamage.tag))
        {
            if (life != null)
            {
                life.TakeDamage(damage);
                isSendDamaged = true;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                isSendDamaged = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTakeDamage.tag) && isEnabled && !isSendDamaged && !isTouchHammerCollider)
        {
            if (life != null)
            {
                life.TakeDamage(damage);
                isSendDamaged = true;
            }
            else if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                isSendDamaged = true;
            }
        }
    }
}
