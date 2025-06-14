using UnityEngine;

public class Hadiah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "pemain1" || other.gameObject.name == "pemain2")
        {
            other.transform.localScale += new Vector3(0.2f, 0.2f, 0);
            FindObjectOfType<HadiahController>()?.HadiahDiambil();
        }
    }
}
