using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float batasAtas;
    public float batasBawah;
    public float batasKiri;
    public float batasKanan;

    public float kecepatan;

    public string verticalAxis = "Vertical";   // Gerak atas-bawah (Y)
    public string horizontalAxis = "Horizontal"; // Gerak kiri-kanan (X)

    void Update()
    {
        float gerakY = Input.GetAxis(verticalAxis) * kecepatan * Time.deltaTime;
        float gerakX = Input.GetAxis(horizontalAxis) * kecepatan * Time.deltaTime;

        float nextPosY = transform.position.y + gerakY;
        float nextPosX = transform.position.x + gerakX;

        // Batas atas-bawah (Y)
        if (nextPosY > batasAtas || nextPosY < batasBawah)
        {
            gerakY = 0;
        }

        // Batas kiri-kanan (X), termasuk batas tengah
        if (nextPosX > batasKanan || nextPosX < batasKiri)
        {
            gerakX = 0;
        }

        transform.Translate(gerakX, gerakY, 0);
    }
}
