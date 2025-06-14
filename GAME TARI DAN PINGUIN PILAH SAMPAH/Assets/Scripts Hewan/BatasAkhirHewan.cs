using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatasAkhirHewan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Bisa tambahkan logika inisialisasi di sini
    }

    // Update is called once per frame
    void Update()
    {
        // Bisa tambahkan logika update di sini
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SceneManager.LoadScene("GameOverHewan");
    }
}
