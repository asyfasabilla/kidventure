using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculHewan : MonoBehaviour
{
    public float jeda = 0.8f; // jeda waktu antar hewan
    private float timer = 0f; // timer internal

    public GameObject[] obyekHewan; // array prefab hewan
    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > jeda && obyekHewan.Length > 0)
        {
            int random = Random.Range(0, obyekHewan.Length);

            if (obyekHewan[random] != null)
            {
                Instantiate(obyekHewan[random], transform.position, transform.rotation);
            }

            timer = 0f;
        }
    }
}
