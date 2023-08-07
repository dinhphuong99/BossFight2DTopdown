using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSycthe : MonoBehaviour
{
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject skillPrefab;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected Vector2 bulletDirect;

    private void OnEnable()
    {
        SpawnBullet();
    }

    protected virtual void SpawnBullet()
    {
        var bullet = Instantiate(skillPrefab, spawnPoint.position, spawnPoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletDirect.normalized * speed, ForceMode2D.Impulse);
    }
}
