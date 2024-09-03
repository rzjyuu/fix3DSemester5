using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLineRenderer : MonoBehaviour
{
    public Transform gunOrigin; // Titik awal di mana tembakan dimulai, biasanya ujung senjata
    public float maxDistance = 100f; // Jarak maksimum dari tembakan

    private LineRenderer lineRenderer;
    private Camera mainCamera;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main; // Mendapatkan referensi ke kamera utama
        lineRenderer.positionCount = 2; // Pastikan LineRenderer memiliki 2 titik
    }

    void Update()
    {
        // Set titik awal garis di posisi asal senjata
        lineRenderer.SetPosition(0, gunOrigin.position);

        // Arahkan ray dari kamera ke posisi mouse di layar
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Jika Raycast mengenai sesuatu, titik akhir garis adalah lokasi hit
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Jika tidak mengenai apapun, titik akhir berada pada jarak maksimum dari posisi mouse
            Vector3 targetPosition = ray.origin + ray.direction * maxDistance;
            lineRenderer.SetPosition(1, targetPosition);
        }
    }
}
