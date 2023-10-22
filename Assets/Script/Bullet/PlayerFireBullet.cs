using UnityEngine;

public class PlayerFireBullet : FireBullet
{
    protected LifeWithRevival playerLife;
    [SerializeField] private float eneryPerBullet = 10f;

    protected override void Start()
    {
        rotateWeapon = GetComponent<RotateWeapon>();
        bulletDirect = rotateWeapon.LookDirection;
        playerLife = this.transform.parent.gameObject.GetComponent<LifeWithRevival>();
        isCooldown = false;
    }

    protected override void Update()
    {
        bulletDirect = rotateWeapon.LookDirection;

        if (isCooldown)
        {
            if (Time.timeScale != 0f)
            {
                fireTimer += Time.unscaledDeltaTime;
            }

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

        if (isAuto || (Input.GetMouseButton(0) && !isCooldown && playerLife.GetCurrentEnergy() > 0))
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
            playerLife.ReduceEnergy(eneryPerBullet);
            isCooldown = true;
        }
    }
}