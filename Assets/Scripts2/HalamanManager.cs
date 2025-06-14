// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class HalamanManager : MonoBehaviour
// {
//     public bool isEscapeToExit;

//     // Tambahan: referensi ke panel selesai
//     public GameObject panelSelesai;
//     private bool permainanSelesai = false;

//     void Start()
//     {
//         if (panelSelesai != null)
//         {
//             panelSelesai.SetActive(false); // pastikan panel disembunyikan di awal
//         }
//     }

//     void Update()
//     {
//         if (Input.GetKeyUp(KeyCode.Escape))
//         {
//             if (isEscapeToExit)
//             {
//                 Application.Quit();
//             }
//             else
//             {
//                 KembaliKeMenu();
//             }
//         }

//         // Simulasi game selesai (tekan Space)
//         if (!permainanSelesai && Input.GetKeyDown(KeyCode.Space))
//         {
//             TampilkanPanelSelesai();
//         }
//     }

//     // Fungsi untuk munculin panel selesai
//     public void TampilkanPanelSelesai()
//     {
//         permainanSelesai = true;
//         if (panelSelesai != null)
//         {
//             panelSelesai.SetActive(true);
//         }
//     }

//     public void MulaiPermainan()
//     {
//         SceneManager.LoadScene("Main");
//     }

//     public void KembaliKeMenu()
//     {
//         SceneManager.LoadScene("Menu");
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;  // Untuk menggunakan EditorApplication.isPlaying
#endif

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
        string currentScene = SceneManager.GetActiveScene().name;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (currentScene == "Menu") // Jika scene saat ini adalah Menu
            {
                // Keluar dari permainan jika kita berada di scene menu
                #if UNITY_EDITOR
                EditorApplication.isPlaying = false;  // Hentikan permainan di editor Unity
                #else
                Application.Quit();  // Keluar dari aplikasi jika build sudah dijalankan
                #endif
            }
            else if (isEscapeToExit) // Jika Escape untuk keluar
            {
                #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
            }
            else
            {
                KembaliKeMenu(); // Kembali ke menu
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

    public void KembaliKeMenuUtama()
    {
        SceneManager.LoadScene("MenuUtama");
    }
}
