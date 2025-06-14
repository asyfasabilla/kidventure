using UnityEngine;
using UnityEngine.UI;

public class GerakTarian : MonoBehaviour
{
    public Text txtJudul;
    public Text txtAsal;
    public Text txtDeskripsi;
    public AudioSource[] audioSources;

    int idx = 0;
    float[] posX = { 0.1f, -16.1f, -32.1f, -48.1f, -64.1f, -80.1f, -96.1f, -112.1f }; // Posisi tiap tarian

    string[] judul = { "TARI KECAK", "TARI GAMBYONG", "TARI KIPAS", "TARI PIRING", "TARI REOG PONOROGO", "TARI SAMAN", "TARI TOPENG", "TARI TOR-TOR" };
    string[] asal = { "BALI", "JAWA TENGAH", "SULAWESI SELATAN", "SUMATERA BARAT", "JAWA TIMUR", "ACEH", "JAWA BARAT", "SUMATERA UTARA" };
    string[] deskripsi = {
        "Tarian Kecak adalah tarian dengan paduan suara 'cak-cak-cak' yang dilakukan oleh puluhan pria.\nMenggambarkan kisah Ramayana, khususnya pertempuran Hanoman melawan Rahwana.",
        "Tarian Gambyong memiliki gerakan yang lemah gemulai serta anggun.\nTarian ini dipertunjukkan untuk menyambut tamu kehormatan.",
        "Tarian tradisional Bugis-Makassar yang menggunakan kipas sebagai properti utama.\nGerakannya lemah gemulai dan penuh makna, sering ditampilkan dalam upacara pernikahan atau penyambutan tamu.",
        "Tarian Piring adalah tarian tradisional Minangkabau yang menampilkan keahlian para penari dalam membawa piring di telapak tangan mereka tanpa terjatuh.\nTarian ini melambangkan kegembiraan dan syukur dalam budaya Minang.",
        "Reog Ponorogo adalah seni tari yang identik dengan barongan berbentuk kepala singa raksasa yang dihiasi bulu merak.\nTarian ini sering dikaitkan dengan legenda dan mistisisme dari Ponorogo.",
        "Tarian Saman dilakukan secara berkelompok dengan gerakan tangan yang cepat dan harmonis.\nBiasanya, tarian ini diiringi syair berisi pesan keagamaan atau nasihat.",
        "Tarian Topeng adalah tarian yang menggunakan topeng sebagai elemen utama.\nTarian ini memiliki berbagai variasi tergantung daerahnya, seperti Tari Topeng Cirebon yang menggambarkan karakter dalam cerita Panji.",
        "Tor-Tor adalah tarian tradisional suku Batak yang memiliki gerakan khas berupa hentakan kaki dan gerakan tangan yang penuh makna.\nTarian ini biasanya diiringi oleh musik gondang."
    };

    void Start()
    {
        UpdateTeks();
        if (audioSources.Length > 0)
        {
            audioSources[idx].Play(); // Mainkan audio pertama saat mulai
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < judul.Length - 1)
            {
                audioSources[idx].Stop();
                idx++;
                audioSources[idx].Play();
                UpdateTeks();
                PindahPosisi();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                audioSources[idx].Stop();
                idx--;
                audioSources[idx].Play();
                UpdateTeks();
                PindahPosisi();
            }
        }
    }

    void UpdateTeks()
    {
        txtJudul.text = judul[idx];
        txtAsal.text = asal[idx];
        txtDeskripsi.text = deskripsi[idx];
    }

    void PindahPosisi()
    {
        transform.position = new Vector3(posX[idx], transform.position.y, transform.position.z);
    }
}