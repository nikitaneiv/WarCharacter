using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform gunEnd;

    private Player player;
    private bool canShoot = true;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (player.IsButtonShootPressed && canShoot && player.isShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        canShoot = false;

        Bullet bullet = Instantiate(bulletPrefab, gunEnd.position, Quaternion.identity);
        bullet.Shoot(gunEnd.forward);

        Invoke("ResetShoot", fireRate);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    public void StartShoot()
    {
        canShoot = true;
    }
}