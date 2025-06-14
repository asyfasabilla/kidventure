using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManagerHewan : MonoBehaviour
{
    [Header("Pengaturan")]
    public bool isEscapeToExit = false;         // Centang di Inspector jika Escape untuk keluar aplikasi
    public GameObject panelSelesai;             // Panel UI yang ditampilkan saat permainan selesai

    private bool permainanSelesai = false;

    void Start()
    {
        if (panelSelesai != null)
        {
            panelSelesai.SetActive(false);
        }
        else
        {
            Debug.LogWarning("PanelSelesai belum di-assign di Inspector!");
        }
    }

    void Update()
    {
        // Tekan Escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Debug.Log("Keluar dari aplikasi");
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
            {
                KembaliKeMenu();
            }
        }

        // Tekan Spasi untuk menyelesaikan permainan
        if (!permainanSelesai && Input.GetKeyDown(KeyCode.Space))
        {
            TampilkanPanelSelesai();
        }
    }

    public void TampilkanPanelSelesai()
    {
        permainanSelesai = true;
        if (panelSelesai != null)
        {
            panelSelesai.SetActive(true);
        }
    }

    public void MulaiPermainan()
    {
        Debug.Log("MulaiPermainan dipanggil");
        Data.score = 0;
        SceneManager.LoadScene("MulaiPermainan");
    }

    public void KembaliKeMenu()
    {
        Debug.Log("Kembali ke menu SebelumPermainan");
        Data.score = 0;
        SceneManager.LoadScene("SebelumPermainan");
    }

    public void KembaliKeMenuUtama()
    {
        Debug.Log("Kembali ke MenuUtama");
        SceneManager.LoadScene("MenuUtama");
    }
}
