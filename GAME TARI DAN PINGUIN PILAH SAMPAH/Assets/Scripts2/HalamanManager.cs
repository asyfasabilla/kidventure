using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;

    // Tambahan: referensi ke panel selesai
    public GameObject panelSelesai;
    private bool permainanSelesai = false;

    void Start()
    {
        if (panelSelesai != null)
        {
            panelSelesai.SetActive(false); // pastikan panel disembunyikan di awal
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }

        // Simulasi game selesai (tekan Space)
        if (!permainanSelesai && Input.GetKeyDown(KeyCode.Space))
        {
            TampilkanPanelSelesai();
        }
    }

    // Fungsi untuk munculin panel selesai
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
        SceneManager.LoadScene("Main");
    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
