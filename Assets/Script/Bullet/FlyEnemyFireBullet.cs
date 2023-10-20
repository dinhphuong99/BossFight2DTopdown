using UnityEngine;

public class FlyEnemyFireBullet : FireBullet
{
    [SerializeField] private GameObject targetObject;

    protected override void Start()
    {
        isCooldown = false;
    }

    protected override void Update()
    {
        bulletDirect = Vector3.zero;
        bulletDirect.x = -transform.position.x + targetObject.transform.position.x;
        bulletDirect.y = -transform.position.y + targetObject.transform.position.y;

        if (isCooldown)
        {
            fireTimer += Time.unscaledDeltaTime;

            if (fireTimer >= fireTime)
            {
                fireTimer = 0f;
                isCooldown = false;
            }
            else
            {
                isCooldown = true;
            }
        }

        if (isAuto)
        {
            BulletLaunch();
        }
    }

    protected override void BulletLaunch()
    {
        if (!isCooldown)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletDirect.normalized * bulletSpeed, ForceMode2D.Impulse);
            isCooldown = true;
        }
    }
}
