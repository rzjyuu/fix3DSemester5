using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject cb = Instantiate(bullet, spawnPosition.position, bullet.transform.rotation);
        Rigidbody rb = cb.GetComponent<Rigidbody>();
        rb.AddForce(spawnPosition.forward * speed, ForceMode.Impulse);
    }
}
