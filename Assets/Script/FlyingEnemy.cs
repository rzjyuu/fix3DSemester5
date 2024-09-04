using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : MonoBehaviour
{
    public Transform player;
    public float hoverHeight = 10f; // Ketinggian melayang

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false; // Mematikan update pada sumbu Y agar agent tidak terpengaruh oleh ketinggian permukaan
    }

    void Update()
    {
        // Set tujuan agent ke posisi pemain
        agent.SetDestination(player.position);

        // Set ketinggian tetap agar musuh melayang
        Vector3 targetPosition = new Vector3(transform.position.x, hoverHeight, transform.position.z);
        transform.position = targetPosition;

        // Hitung arah ke pemain
        Vector3 direction = player.position - transform.position;

        // Buat rotasi yang menghadap ke pemain
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Terapkan rotasi ke musuh (hanya pada sumbu Y)
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
