// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
 
// public class GameOver : MonoBehaviour
// {
 
//     float timer = 0;
//     // Update is called once per frame
//     void Update()
//     {
//         timer += Time.deltaTime;
//         if (timer > 2)
//         {
//             Data.score = 0;
//             SceneManager.LoadScene("MulaiPermainan");
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource audioSource; // drag AudioSource dari Inspector

    float timer = 0;
    bool soundPlayed = false;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            soundPlayed = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.5f) // beri waktu lebih lama supaya sound selesai
        {
            Data.score = 0;
            SceneManager.LoadScene("MulaiPermainan");
        }
    }
}
