using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSendDamage : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectTakeDamage;
    private bool isTouch = false;
    [SerializeField] private float damage = 10f;
    private Life life;
    private PlayerLife playerLife;
    private bool isSent = true;

    // Start is called before the first frame update
    void Start()
    {
        this.isSent = true;
        life = GameObjectTakeDamage.GetComponent<Life>();
        playerLife = GameObjectTakeDamage.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouch = GetComponent<DetectionCollider>().isTouch;

        if (isTouch && !isSent)
        {
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

    public void SetFalse2IsSent()
    {
        this.isSent = false;
    }

    public void SetTrue2IsSent()
    {
        this.isSent = true;
    }
}
