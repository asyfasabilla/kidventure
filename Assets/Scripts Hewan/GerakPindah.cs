using UnityEngine;
using UnityEngine.UI;

public class GerakPindah : MonoBehaviour
{
    public Sprite[] sprites;
    private float speed = 1f;
    public string namaGameObjectSkor = "Score"; // Nama GameObject yang memiliki skrip DeteksiHewan
    private DeteksiHewan deteksiHewan;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;

    public Text textScore;

    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];

        CariDeteksiHewanSaatSiap();
    }

    void CariDeteksiHewanSaatSiap()
    {
        GameObject skorObject = GameObject.Find(namaGameObjectSkor);
        if (skorObject != null)
        {
            deteksiHewan = skorObject.GetComponent<DeteksiHewan>();
            if (deteksiHewan == null)
            {
                Debug.LogError("Skrip DeteksiHewan tidak ditemukan pada GameObject: " + namaGameObjectSkor);
            }
        }
        else
        {
            Debug.LogError("GameObject dengan nama: " + namaGameObjectSkor + " tidak ditemukan.");
        }
    }

    void Update()
    {
        if (deteksiHewan != null)
        {
            int kenaikan = Data.score / 50;
            speed = 1f + kenaikan; // kecepatan naik setiap skor 50
        }

        float move = (speed * Time.deltaTime * -1f) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y);
    }

    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
    }
}
