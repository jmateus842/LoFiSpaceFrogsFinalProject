using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootPoint; // Point from where the bullet is shot
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instantiate a bullet at the shoot point
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        
        // Shoot the bullet forward
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
    }
}
