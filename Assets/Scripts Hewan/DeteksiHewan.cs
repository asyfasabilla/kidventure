// // using UnityEngine;
// // using UnityEngine.UI;

// // public class DeteksiHewan : MonoBehaviour
// // {
// //     public string nameTag;
// //     public AudioClip audioBenar;
// //     public AudioClip audioSalah;
// //     private AudioSource MediaPlayerBenar;
// //     private AudioSource MediaPlayerSalah;
// //     public Text textScore;


// //     // Use this for initialization
// //     void Start()
// //     {
// //         MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
// //         MediaPlayerBenar.clip = audioBenar;


// //         MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
// //         MediaPlayerSalah.clip = audioSalah;
// //     }


// //     void OnTriggerEnter2D(Collider2D collision)
// //     {
// //         if (collision.tag.Equals(nameTag))
// //         {
// //             Data.score += 25;
// //             textScore.text = Data.score.ToString();
// //             Destroy(collision.gameObject);
// //             MediaPlayerBenar.Play();
// //         }
// //         else
// //         {
// //             Data.score -= 5;
// //             textScore.text = Data.score.ToString();
// //             Destroy(collision.gameObject);
// //             MediaPlayerSalah.Play();
// //         }
// //     }
// // }

// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;

// public class DeteksiHewan : MonoBehaviour
// {
//     public string nameTag;
//     public AudioClip audioBenar;
//     public AudioClip audioSalah;
//     private AudioSource MediaPlayerBenar;
//     private AudioSource MediaPlayerSalah;
//     public Text textScore;

//     public SpriteRenderer boxRenderer; // gunakan SpriteRenderer, bukan Image
//     private Color defaultColor;

//     void Start()
//     {
//         MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
//         MediaPlayerBenar.clip = audioBenar;

//         MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
//         MediaPlayerSalah.clip = audioSalah;

//         if (boxRenderer != null)
//             defaultColor = boxRenderer.color;
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag.Equals(nameTag))
//         {
//             Data.score += 25;
//             textScore.text = Data.score.ToString();
//             Destroy(collision.gameObject);
//             MediaPlayerBenar.Play();

//             if (boxRenderer != null)
//                 StartCoroutine(FlashBoxColor(Color.green));
//         }
//         else
//         {
//             Data.score -= 5;
//             textScore.text = Data.score.ToString();
//             Destroy(collision.gameObject);
//             MediaPlayerSalah.Play();

//             if (boxRenderer != null)
//                 StartCoroutine(FlashBoxColor(Color.red));
//         }
//     }

//     IEnumerator FlashBoxColor(Color flashColor)
//     {
//         boxRenderer.color = flashColor;
//         yield return new WaitForSeconds(0.3f);
//         boxRenderer.color = defaultColor;
//     }
// }


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeteksiHewan : MonoBehaviour
{
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah;
    public Text textScore;

    public GameObject neonEffect; // GameObject yang berisi sprite neon

    void Start()
    {
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        MediaPlayerBenar.clip = audioBenar;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        MediaPlayerSalah.clip = audioSalah;

        if (neonEffect != null)
            neonEffect.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 25;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerBenar.Play();

            if (neonEffect != null)
                StartCoroutine(ShowNeon(Color.green));
        }
        else
        {
            Data.score -= 5;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerSalah.Play();

            if (neonEffect != null)
                StartCoroutine(ShowNeon(Color.red));
        }
    }

    IEnumerator ShowNeon(Color color)
    {
        neonEffect.SetActive(true);
        SpriteRenderer sr = neonEffect.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = color;
        }

        yield return new WaitForSeconds(0.3f);

        neonEffect.SetActive(false);
    }
}
