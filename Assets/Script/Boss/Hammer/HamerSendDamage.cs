using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamerSendDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private Life life;
    private PlayerLife playerLife;
    [SerializeField] private GameObject GameObjectTakeDamage;
    [SerializeField] private GameObject sinkholeCrackCollider;
    [SerializeField] private GameObject hammerCollider;
    [SerializeField] private GameObject sinkholeCrackPrefab;
    private bool isTouchSinkholeCrackCollider = false;
    private bool isTouchHammerCollider = false;
    private float bonusDamage;
    private bool isEnabled = false;
    private bool isSendDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        bonusDamage = sinkholeCrackPrefab.GetComponent<SinkholeCrackSendDamage>().damage;
        life = GameObjectTakeDamage.GetComponent<Life>();
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        isEnabled = hammerCollider.GetComponent<PolygonCollider2D>().isActiveAndEnabled;
        isTouchSinkholeCrackCollider = sinkholeCrackCollider.GetComponent<DetectionCollider>().isTouch;
        isTouchHammerCollider = hammerCollider.GetComponent<DetectionCollider>().isTouch;

        if (!isEnabled)
        {
            isSendDamaged = false;
        }

        if (isEnabled && !isSendDamaged)
        {
            if (isTouchHammerCollider && isTouchSinkholeCrackCollider)
            {
                if (life != null)
                {
                    life.TakeDamage(damage + bonusDamage);
                    isSendDamaged = true;
                }
                else if (playerLife != null)
                {
                    playerLife.TakeDamage(damage + bonusDamage);
                    isSendDamaged = true;
                }
            }
            else if (!isTouchHammerCollider && isTouchSinkholeCrackCollider)
            {
                if (life != null)
                {
                    life.TakeDamage(bonusDamage);
                    isSendDamaged = true;
                }
                else if (playerLife != null)
                {
                    playerLife.TakeDamage(bonusDamage);
                    isSendDamaged = true;
                }
            }
            else if (isTouchHammerCollider && !isTouchSinkholeCrackCollider)
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
}
