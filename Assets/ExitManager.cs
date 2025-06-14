using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject confirmExitPanel;
    public Button exitButton;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        // Sembunyikan panel konfirmasi di awal
        confirmExitPanel.SetActive(false);

        // Tambahkan listener ke tombol
        exitButton.onClick.AddListener(ShowConfirmExit);
        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(HideConfirmExit);
    }

    void ShowConfirmExit()
    {
        confirmExitPanel.SetActive(true);
    }

    void HideConfirmExit()
    {
        confirmExitPanel.SetActive(false);
    }

    void ExitGame()
    {
        // Jika dijalankan di editor Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Jika dijalankan sebagai build aplikasi
        Application.Quit();
#endif
    }
}
