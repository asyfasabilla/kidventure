using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force = 800;
    private Rigidbody2D rigid;

    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public Text scoreTextP1;
    public Text scoreTextP2;
    public Text textTimer;

    public GameObject panelSelesai;
    Text txPemenang;

    AudioSource audio;
    public AudioClip hitSound;
    public AudioClip winSound;

    public float waktuPermainan = 30f;
    private float timer;

    private bool gameEnded = false;
    private AudioSource backsound;
    private bool isWinSoundPlaying = false;

    public float maxSpeed = 15f; // Batas kecepatan bola

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (panelSelesai != null)
            panelSelesai.SetActive(false);

        GameObject timerObj = GameObject.Find("TextTimer");
        if (timerObj != null)
            textTimer = timerObj.GetComponent<Text>();

        timer = waktuPermainan;

        MulaiGame();
        audio = GetComponent<AudioSource>();

        GameObject kamera = GameObject.Find("Main Camera");
        if (kamera != null)
            backsound = kamera.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameEnded)
        {
            timer -= Time.deltaTime;

            if (textTimer != null)
                textTimer.text = Mathf.CeilToInt(timer).ToString();

            if (timer <= 0f)
            {
                timer = 0f;
                gameEnded = true;
                StartCoroutine(DelayCekPemenang());
            }

            // Batasi kecepatan bola
            if (rigid.velocity.magnitude > maxSpeed)
                rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
    }

    System.Collections.IEnumerator DelayCekPemenang()
    {
        yield return new WaitForSeconds(0.5f);
        CekPemenangByTimer();
    }

    void MulaiGame()
    {
        if (backsound != null && !backsound.isPlaying)
            backsound.Play();

        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (gameEnded) return;

        audio.PlayOneShot(hitSound);

        switch (coll.gameObject.name)
        {
            case "batas kanan":
                scoreP1++;
                break;

            case "batas kiri":
                scoreP2++;
                break;

            case "pemain1":
            case "pemain2":
                float sudut = (transform.position.y - coll.transform.position.y) * 2f; // Diperhalus
                float arahX = coll.gameObject.name == "pemain1" ? 1f : -1f;
                Vector2 arah = new Vector2(arahX, sudut).normalized;

                rigid.velocity = Vector2.zero;
                rigid.AddForce(arah * force * 2);
                return;

            case "batas atas":
            case "batas bawah":
                Vector2 currentVelocity = rigid.velocity;
                currentVelocity.y = -currentVelocity.y * 0.9f; // Direm sedikit agar tidak liar
                rigid.velocity = currentVelocity;
                return;
        }

        TampilkanScore();
        ResetBall();

        Vector2 arahBaru = coll.gameObject.name == "batas kanan"
            ? new Vector2(2, 0).normalized
            : new Vector2(-2, 0).normalized;

        rigid.AddForce(arahBaru * force);
    }

    void ResetBall()
    {
        transform.localPosition = Vector2.zero;
        rigid.velocity = Vector2.zero;
    }

    void TampilkanScore()
    {
        if (scoreTextP1 != null)
            scoreTextP1.text = scoreP1.ToString();
        if (scoreTextP2 != null)
            scoreTextP2.text = scoreP2.ToString();
    }

    void CekPemenangByTimer()
    {
        TampilkanScore();

        if (panelSelesai != null)
            panelSelesai.SetActive(true);

        GameObject teksPemenangObj = GameObject.Find("Pemenang");
        if (teksPemenangObj != null)
        {
            txPemenang = teksPemenangObj.GetComponent<Text>();

            if (scoreP1 > scoreP2)
                txPemenang.text = "Player Kiri Pemenang!";
            else if (scoreP2 > scoreP1)
                txPemenang.text = "Player Kanan Pemenang!";
            else
                txPemenang.text = "Seri!";
        }

        PlayWinSound();

        if (backsound != null)
            backsound.Stop();

        rigid.velocity = Vector2.zero;
        rigid.isKinematic = true;
    }

    void PlayWinSound()
    {
        if (!isWinSoundPlaying)
        {
            audio.clip = winSound;
            audio.loop = true;
            audio.Play();
            isWinSoundPlaying = true;
        }
    }

    public void StopWinSound()
    {
        if (isWinSoundPlaying)
        {
            audio.loop = false;
            audio.Stop();
            isWinSoundPlaying = false;
        }
    }
}