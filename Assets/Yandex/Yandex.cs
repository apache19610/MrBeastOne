using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();


    void Start()
    {
        ShowAdv();
    }

    public void OpenAdv()
    {
        Time.timeScale = 0;
    }

    public void CloseAdv()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {

    }


    public static void ShowAdvSleep()
    {
        ShowAdv();
    }

}
