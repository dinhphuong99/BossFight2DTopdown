using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed = 3f;
    [SerializeField] protected float fireTime = 0.4f;
    [SerializeField] protected bool isAuto = false;
    protected Vector2 bulletDirect;
    protected float fireTimer = 0f;
    protected float lastTime;
    protected bool isDestroy = false;
    protected bool isCooldown;
    protected RotateWeapon rotateWeapon;


    protected virtual void Start()
    {
        rotateWeapon = GetComponent<RotateWeapon>();
        bulletDirect = rotateWeapon.LookDirection;
        isCooldown = false;
    }

    protected virtual void Update()
    {
        bulletDirect = rotateWeapon.LookDirection;
        
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

        if ((isAuto || Input.GetMouseButton(0)) && !isCooldown)
        {
            BulletLaunch();
        }
    }

    protected virtual void BulletLaunch()
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
