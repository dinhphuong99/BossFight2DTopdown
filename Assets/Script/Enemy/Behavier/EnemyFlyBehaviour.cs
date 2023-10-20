using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyBehaviour : MonoBehaviour
{
    private EnemyRunAway enemyRunAway;
    private FlyEnemyFireBullet flyEnemyFireBullet;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private GameObject body;
    private Vector3 vectorMove = Vector3.zero;
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRunAway = GetComponent<EnemyRunAway>();
        flyEnemyFireBullet = GetComponent<FlyEnemyFireBullet>();
        rb = GetComponent<Rigidbody2D>();
        sprite = body.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        vectorMove = enemyRunAway.moveInput;
        speed = enemyRunAway.GetSpeed();

        if(rb.bodyType == RigidbodyType2D.Dynamic)
        {
            transform.position += vectorMove.normalized * speed * Time.deltaTime;
        }

        Flip();

        if (enemyRunAway.getCanFireBullet())
        {
            flyEnemyFireBullet.enabled = true;
        }
        else
        {
            flyEnemyFireBullet.enabled = false;
        }
    }

    private void Flip()
    {
        if (vectorMove.x < 0)
        {
            sprite.flipX = true;
        }
        else if (vectorMove.x > 0)
        {
            sprite.flipX = false;
        }
    }
}
