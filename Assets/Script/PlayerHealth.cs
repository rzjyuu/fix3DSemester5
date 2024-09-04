using UnityEngine;
using UnityEngine.UI; // Import untuk akses ke UI elements

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Nilai maksimum health
    public int currentHealth;   // Nilai health saat ini
    public Slider healthSlider; // Referensi ke UI Slider

    void Start()
    {
        currentHealth = maxHealth; // Set health awal ke maksimum
        UpdateHealthUI();          // Update UI health awal
    }

    void Update()
    {
        // Contoh: tekan tombol "H" untuk mengurangi health sebagai simulasi
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10); // Mengurangi health 10 poin setiap kali tombol H ditekan
        }
    }

    // Fungsi untuk mengurangi health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Kurangi health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Pastikan health tidak kurang dari 0
        UpdateHealthUI(); // Update UI setelah health berubah
    }

    // Fungsi untuk mengupdate UI Slider
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth; // Set nilai slider sesuai health saat ini
    }
}
