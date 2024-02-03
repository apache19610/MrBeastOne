using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCheckPlatform : MonoBehaviour
{
    public GameObject panel;
    public GameObject imageFon;
    public GameObject mainCamera;
    public GameObject ButtonExit;
    public static bool isPlatforms;

    void Start()
    {
        ButtonExit.SetActive(false);
        Time.timeScale = 0;
        mainCamera.GetComponent<FirstPersonLook>().enabled = false;

    }

    public void CheckPC()
    {
        isPlatforms = true;
        panel.SetActive(false);
        ButtonExit.SetActive(true);
    }

    public void CheckAndroid()
    {
        isPlatforms = false;
        panel.SetActive(true);
        ButtonExit.SetActive(true);
    }

    public void ExitImageFon()
    {
        Time.timeScale = 1;
        imageFon.SetActive(false);
        mainCamera.GetComponent<FirstPersonLook>().enabled = true;
    }
}

