using UnityEngine;

public class HadiahController : MonoBehaviour
{
    public GameObject hadiah;
    private GameObject hadiahAktif1;
    private GameObject hadiahAktif2;

    public float waktuSpawn = 10f; // hanya sekali, di detik 10
    private float timer = 0f;
    private bool hadiahSudahSpawned = false;
    private bool sudahSpawnSekali = false;

    void Update()
    {
        if (sudahSpawnSekali) return; // kalau sudah pernah spawn, stop

        timer += Time.deltaTime;

        if (!hadiahSudahSpawned && timer >= waktuSpawn)
        {
            SpawnHadiahKiriKanan();
            hadiahSudahSpawned = true;
            sudahSpawnSekali = true; // tandai bahwa hadiah sudah pernah muncul
        }
    }

    void SpawnHadiahKiriKanan()
    {
        if (hadiah != null)
        {
            // Kiri (area pemain 1)
            float xKiri = Random.Range(-8.5f, -1.5f);
            float yKiri = Random.Range(-3f, 3f);

            // Kanan (area pemain 2)
            float xKanan = Random.Range(2f, 8.5f);
            float yKanan = Random.Range(-3f, 3f);

            hadiahAktif1 = Instantiate(hadiah, new Vector2(xKiri, yKiri), Quaternion.identity);
            hadiahAktif2 = Instantiate(hadiah, new Vector2(xKanan, yKanan), Quaternion.identity);
        }
    }

    public void HadiahDiambil()
    {
        if (hadiahAktif1 != null) Destroy(hadiahAktif1);
        if (hadiahAktif2 != null) Destroy(hadiahAktif2);
    }
}
