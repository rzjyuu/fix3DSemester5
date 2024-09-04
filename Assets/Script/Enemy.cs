using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    public void Die()
    {
        // Logika musuh mati
        enemyManager.EnemyDefeated(); // Panggil EnemyDefeated di EnemyManager
        Destroy(gameObject);
    }
}