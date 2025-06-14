// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameOver : MonoBehaviour
// {
//     float timer = 0f;

//     // Update is called once per frame
//     void Update()
//     {
//         timer += Time.deltaTime;

//         if (timer > 2f)
//         {
//             Data.score = 0;
//             SceneManager.LoadScene("MulaiPermainan");
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameOver : MonoBehaviour
// {
//     [Header("Delay sebelum Game Over")]
//     public float delay = 2f;

//     [Header("Panel Game Over")]
//     public GameObject gameOverPanel;

//     private float timer = 0f;
//     private bool isGameOver = false;

//     void Start()
//     {
//         // Sembunyikan panel di awal
//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(false);

//         // Pastikan score di‐reset jika scene ini juga pernah dipakai ulang
//         Data.score = 0;
//     }

//     void Update()
//     {
//         if (isGameOver) return;

//         timer += Time.deltaTime;
//         if (timer > delay)
//         {
//             isGameOver = true;
//             ShowGameOver();
//         }
//     }

//     private void ShowGameOver()
//     {
//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(true);
//         else
//             Debug.LogError("GameOver: gameOverPanel belum diset di Inspector");
//     }

//     // Dipanggil oleh tombol “Ulangi” di panel Game Over
//     public void OnRetry()
//     {
//         // Reset score sebelum reload
//         Data.score = 0;
//         SceneManager.LoadScene("MulaiPermainan");
//     }

//     // Dipanggil oleh tombol “Kembali ke Menu” di panel Game Over
//     public void OnMainMenu()
//     {
//         Data.score = 0;
//         SceneManager.LoadScene("SebelumPermainan");
//     }
// }
