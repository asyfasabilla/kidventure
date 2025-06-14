// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.SceneManagement;
 
// // public class KelolaScene : MonoBehaviour
// // {
 
// //     public string EnterScene;
// //     public string EscapeScene;
// //     public bool isEscapeForQuit = true;
 
// //     // Use this for initialization
// //     void Start()
// //     {
 
// //     }
 
// //     // Update is called once per frame
// //     void Update()
// //     {
// //         if (Input.GetKeyUp(KeyCode.Return))
// //         {
// //             Debug.Log("Name Scene: " + EnterScene);
// //             SceneManager.LoadScene(EnterScene);
// //         }
 
// //         if (Input.GetKeyUp(KeyCode.Escape))
// //         {
// //             if (isEscapeForQuit)
// //             {
// //                 Application.Quit();
// //             }
// //             else
// //             {
// //                 Debug.Log("Name Scene: " + EscapeScene);
// //                 SceneManager.LoadScene(EscapeScene);
// //             }
// //         }
// //     }
// // }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class KelolaScene : MonoBehaviour
// {
//     public string EnterScene;
//     public string EscapeScene;
//     public bool isEscapeForQuit = true;

//     void Update()
//     {
//         // Tekan Enter untuk masuk scene tertentu
//         if (Input.GetKeyUp(KeyCode.Return))
//         {
//             Debug.Log("Name Scene: " + EnterScene);
//             SceneManager.LoadScene(EnterScene);
//         }

//         // Tekan Escape untuk keluar atau kembali ke scene tertentu
//         if (Input.GetKeyUp(KeyCode.Escape))
//         {
//             if (isEscapeForQuit)
//             {
//                 Application.Quit();
//                 Debug.Log("Keluar dari game");
//             }
//             else
//             {
//                 Debug.Log("Name Scene: " + EscapeScene);
//                 SceneManager.LoadScene(EscapeScene);
//             }
//         }
//     }
// }

#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KelolaScene : MonoBehaviour
{
    public string EnterScene;
    public string EscapeScene;
    public bool isEscapeForQuit = true;

    void Update()
    {
        // Tekan Enter untuk masuk scene tertentu
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene: " + EnterScene);
            SceneManager.LoadScene(EnterScene);
        }

        // Tekan Escape untuk keluar atau kembali ke scene tertentu
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                Debug.Log("Keluar dari game");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // keluar dari Play Mode saat di editor
#else
                Application.Quit(); // keluar saat sudah dibuild
#endif
            }
            else
            {
                Debug.Log("Name Scene: " + EscapeScene);
                SceneManager.LoadScene(EscapeScene);
            }
        }
    }
}

