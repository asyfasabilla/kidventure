// using UnityEngine;
// using DG.Tweening; // Pastikan kamu sudah import dan setup DOTween

// public class Kartu : MonoBehaviour
// {
//     private bool flipped = false;

//     [Header("Sisi kartu")]
//     public GameObject sisiDepan;
//     public GameObject sisiBelakang;

//     void Start()
//     {
//         // Tampilkan hanya salah satu sisi saat awal
//         TampilkanSisi(flipped);
//     }

//     void OnMouseDown()
//     {
//         // Ketika kartu diklik, lakukan flip
//         Flip();
//     }

//     public void Flip()
//     {
//         flipped = !flipped;

//         // Animasikan rotasi 180 derajat di sumbu Y
//         transform.DORotate(new Vector3(0, flipped ? 180f : 0f, 0), 0.25f)
//             .OnComplete(() =>
//             {
//                 // Ganti sisi setelah animasi selesai
//                 TampilkanSisi(flipped);
//             });
//     }

//     private void TampilkanSisi(bool isBelakang)
//     {
//         if (sisiDepan != null) sisiDepan.SetActive(!isBelakang);
//         if (sisiBelakang != null) sisiBelakang.SetActive(isBelakang);
//     }
// }

using UnityEngine;
using DG.Tweening;

public class Kartu : MonoBehaviour
{
    private bool flipped = false;

    [Header("Sisi kartu")]
    public GameObject sisiDepan;
    public GameObject sisiBelakang;

    [Header("Suara")]
    public AudioSource flipSound; // Tambahkan AudioSource

    void Start()
    {
        // Tampilkan hanya salah satu sisi saat awal
        TampilkanSisi(flipped);
    }

    void OnMouseDown()
    {
        Flip();
    }

    public void Flip()
    {
        flipped = !flipped;

        // Putar suara jika ada
        if (flipSound != null)
        {
            flipSound.Play();
        }

        // Animasi rotasi
        transform.DORotate(new Vector3(0, flipped ? 180f : 0f, 0), 0.25f)
            .OnComplete(() =>
            {
                TampilkanSisi(flipped);
            });
    }

    private void TampilkanSisi(bool isBelakang)
    {
        if (sisiDepan != null) sisiDepan.SetActive(!isBelakang);
        if (sisiBelakang != null) sisiBelakang.SetActive(isBelakang);
    }
}
