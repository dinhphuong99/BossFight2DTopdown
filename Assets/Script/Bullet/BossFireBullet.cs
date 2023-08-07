using UnityEngine;

public class BossFireBullet : FireBullet
{
    [SerializeField]private Vector2 bulletDirect1;
    [SerializeField] private Vector2 bulletDirect2;
    [SerializeField] private Vector2 bulletDirect3;

    public Vector2 GetBulletDirect1()
    {
        return this.bulletDirect1;
    }

    protected override void Start()
    {
        isCooldown = false;
    }

    protected override void Update()
    {
        
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

        if (isAuto || (Input.GetMouseButton(0) && !isCooldown))
        {
            BulletLaunch();
        }
    }

    protected override void BulletLaunch()
    {
        if (!isCooldown)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            bullet.GetComponent<RoteBullet>().SetVector(bulletDirect1);
            bullet1.GetComponent<RoteBullet>().SetVector(bulletDirect2);
            bullet2.GetComponent<RoteBullet>().SetVector(bulletDirect3);

            var rb = bullet.GetComponent<Rigidbody2D>();
            var rb1 = bullet1.GetComponent<Rigidbody2D>();
            var rb2 = bullet2.GetComponent<Rigidbody2D>();

            rb.AddForce(bulletDirect1.normalized * bulletSpeed, ForceMode2D.Impulse);
            rb1.AddForce(bulletDirect2.normalized * bulletSpeed, ForceMode2D.Impulse);
            rb2.AddForce(bulletDirect3.normalized * bulletSpeed, ForceMode2D.Impulse);

            isCooldown = true;
        }
    }
}
