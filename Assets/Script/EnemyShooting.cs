using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootingInterval = 1f;
    public int numberOfBullets = 8;
    public float bulletSpeed = 5f;

    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootingInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));

            // Set the bullet direction and speed
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

            // Increment the angle for the next bullet
            angle += angleStep;
        }
    }
}
