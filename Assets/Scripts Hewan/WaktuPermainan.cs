using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaktuPermainan : MonoBehaviour
{
    public float waktu = 120f; // 2 menit
    public Text Timer;
    private bool waktuHabis = false;

    void Update()
    {
        if (!waktuHabis)
        {
            waktu -= Time.deltaTime;

            // Hitung menit dan detik
            int menit = Mathf.FloorToInt(waktu / 60f);
            int detik = Mathf.FloorToInt(waktu % 60f);

            Timer.text = string.Format("{0:00}:{1:00}", menit, detik);

            if (waktu <= 0)
            {
                waktuHabis = true;
                TimerHabis();
            }
        }
    }

    void TimerHabis()
    {
        // Contoh: pindah ke scene Game Over, atau tampilkan panel selesai
        SceneManager.LoadScene("GameOverHewan"); // Ganti nama scene sesuai punya kamu
    }
}
