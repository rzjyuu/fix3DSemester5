using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referensi ke transform pemain
    public NavMeshAgent enemy; // Referensi ke NavMeshAgent pada musuh
    public float enemySpeed; // Kecepatan peluru musuh

    [SerializeField] private float timer = 5f; // Waktu jeda antara tembakan (cooldown)
    [SerializeField] private float shootDistance = 10f; // Jarak maksimum untuk menembak
    [SerializeField] private int bulletsPerShot = 10; // Jumlah peluru yang ditembakkan per tembakan
    [SerializeField] private int totalBullets = 100; // Total peluru yang tersisa
    [SerializeField] private Transform[] spawnPoints; // Array titik di mana peluru akan ditembakkan
    [SerializeField] private GameObject enemyBullet; // Prefab peluru musuh

    private float bulletTime; // Waktu yang tersisa sebelum tembakan berikutnya
    private int bulletsRemaining; // Jumlah peluru yang tersisa

    // Start is called before the first frame update
    void Start()
    {
        bulletTime = timer; // Inisialisasi bulletTime dengan timer
        bulletsRemaining = totalBullets; // Inisialisasi jumlah peluru yang tersisa
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position); // Mengatur tujuan musuh untuk mengikuti pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Hitung jarak ke pemain

        // Jika jarak kurang dari shootDistance dan masih ada peluru yang tersisa, maka tembak
        if (distanceToPlayer <= shootDistance && bulletsRemaining > 0)
        {
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime; // Mengurangi waktu setiap frame

        // Jika waktu belum habis, keluar dari fungsi
        if (bulletTime > 0) return;

        bulletTime = timer; // Reset bulletTime

        // Iterasi melalui setiap spawn point dalam array
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Memeriksa apakah ada cukup peluru yang tersisa untuk menembak
            if (bulletsRemaining <= 0)
            {
                break; // Jika peluru habis, keluar dari loop
            }

            // Loop untuk menembakkan beberapa peluru per tembakan
            for (int i = 0; i < bulletsPerShot; i++)
            {
                // Membuat objek peluru dan mengatur posisinya
                GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
                Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>(); // Mendapatkan Rigidbody dari peluru

                // Hitung arah dari spawnPoint ke pemain
                Vector3 directionToPlayer = (player.position - spawnPoint.position).normalized;

                // Menambahkan gaya untuk menembakkan peluru ke arah pemain
                bulletRig.AddForce(directionToPlayer * enemySpeed, ForceMode.Impulse); // Menggunakan Impulse untuk menambah gaya mendadak
                Destroy(bulletObj, 5f); // Menghancurkan peluru setelah 5 detik

                bulletsRemaining--; // Kurangi jumlah peluru yang tersisa
            }
        }
    }
}
