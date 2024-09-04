using UnityEngine;

public class CombinedLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer; // Referensi ke komponen LineRenderer
    public Transform raycastOrigin;   // Titik awal raycast
    public float maxRaycastDistance = 100f; // Jarak maksimum raycast
    public LayerMask hitLayers;       // Layer yang akan ditabrak raycast
    public Camera mainCamera;         // Referensi ke kamera utama

    void Update()
    {
        // Set posisi awal dari LineRenderer (titik 0)
        lineRenderer.SetPosition(0, raycastOrigin.position);

        // Dapatkan posisi mouse dalam ruang dunia
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Lakukan raycast dari posisi kamera ke arah mouse dengan mempertimbangkan LayerMask
        if (Physics.Raycast(ray, out hit, maxRaycastDistance, hitLayers))
        {
            // Jika raycast mengenai objek pada layer yang ditentukan, set posisi akhir LineRenderer ke titik hit
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Jika tidak mengenai objek pada layer yang ditentukan, set posisi akhir LineRenderer pada jarak maksimum
            Vector3 endPosition = ray.origin + ray.direction * maxRaycastDistance;
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
