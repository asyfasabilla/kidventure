// using UnityEngine;
// using UnityEngine.UI;

// public class DeteksiHewan : MonoBehaviour
// {
//     public string nameTag;
//     public AudioClip audioBenar;
//     public AudioClip audioSalah;
//     private AudioSource MediaPlayerBenar;
//     private AudioSource MediaPlayerSalah;
//     public Text textScore;

//     // Use this for initialization
//     void Start()
//     {
//         MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
//         MediaPlayerBenar.clip = audioBenar;

//         MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
//         MediaPlayerSalah.clip = audioSalah;
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag.Equals(nameTag))
//         {
//             Data.score += 25;
//             textScore.text = Data.score.ToString();
//             Destroy(collision.gameObject);
//             MediaPlayerBenar.Play();
//         }
//         else
//         {
//             Data.score -= 5;
//             textScore.text = Data.score.ToString();
//             Destroy(collision.gameObject);
//             MediaPlayerSalah.Play();
//         }
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
    public GameObject efekSalah; // efek merah ditampilkan saat salah

  void Start()
{
    // Setup audio
    MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
    MediaPlayerBenar.clip = audioBenar;

    MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
    MediaPlayerSalah.clip = audioSalah;

    // Matikan efek merah saat awal
    if (efekSalah != null)
    {
        efekSalah.SetActive(false);
    }
}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 25;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerBenar.Play();
        }
        else
        {
            Data.score -= 5;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerSalah.Play();
            SalahMasuk(); // Tampilkan efek jika salah
        }
    }

    void SalahMasuk()
    {
        StartCoroutine(TampilkanEfekMerah());
    }

    IEnumerator TampilkanEfekMerah()
    {
        if (efekSalah != null)
        {
            efekSalah.SetActive(true);
            yield return new WaitForSeconds(0.5f); // muncul 0.5 detik
            efekSalah.SetActive(false);
        }
    }
}
