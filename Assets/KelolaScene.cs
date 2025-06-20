// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
 
// public class KelolaScene : MonoBehaviour
// {
 
//     public string EnterScene;
//     public string EscapeScene;
//     public bool isEscapeForQuit = true;
 
//     // Use this for initialization
//     void Start()
//     {
 
//     }
 
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyUp(KeyCode.Return))
//         {
//             Debug.Log("Name Scene: " + EnterScene);
//             SceneManager.LoadScene(EnterScene);
//         }
 
//         if (Input.GetKeyUp(KeyCode.Escape))
//         {
//             if (isEscapeForQuit)
//             {
//                 Application.Quit();
//             }
//             else
//             {
//                 Debug.Log("Name Scene: " + EscapeScene);
//                 SceneManager.LoadScene(EscapeScene);
//             }
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KelolaScene : MonoBehaviour
{
    public string enterScene;
    public string escapeScene;
    public bool isEscapeForQuit = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene: " + enterScene);
            SceneManager.LoadScene(enterScene);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Name Scene: " + escapeScene);
                SceneManager.LoadScene(escapeScene);
            }
        }
    }
}