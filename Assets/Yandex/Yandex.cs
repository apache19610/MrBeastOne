using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public FirstPersonMovement firstPersonMovement;
    public FirstPersonLook firstPersonLook;
    public GameObject firstpersonaudio;
    public Jump jump;

    void Start()
    {
        Time.timeScale = 1;
        ShowAdv();
    }

    public void OpenAdv()
    {
        firstpersonaudio.SetActive(false);
        firstPersonMovement.speed = 0;
        firstPersonLook.sensitivity = 0;
        jump.jumpStrength = 0;
        Time.timeScale = 0;
    }

    public void CloseAdv()
    {
        firstpersonaudio.SetActive(true);
        firstPersonMovement.speed = 3;
        firstPersonLook.sensitivity = 2;
        jump.jumpStrength = 2;
        Time.timeScale = 1;
    }

    public static void ShowAdvSleep()
    {
        ShowAdv();
    }

    public void MainMenuOpen()
    {
        SceneManager.LoadScene("Main");
        ShowAdv();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        ShowAdv();
    }

}
