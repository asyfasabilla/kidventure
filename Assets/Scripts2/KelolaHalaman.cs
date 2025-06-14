using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KelolaHalaman : MonoBehaviour
{
    //public bool isEscapeToExit;

    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Escape))
    //    {
    //        if (isEscapeToExit)
    //        {
    //            Application.Quit();
    //        }
    //        else
    //        {
    //            KembaliKeMenu();
    //        }
    //    }
    //}

    public void MulaiPermainanTarian()
    {
        SceneManager.LoadScene("Home");
    }

    public void MulaiPermainanPenguin()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MulaiPermainanHewan()
    {
        SceneManager.LoadScene("SebelumPermainan");
    }

    public void MulaiCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    //void KembaliKeMenu()
    //{
    //    SceneManager.LoadScene("MenuUtama");
    //}
}
