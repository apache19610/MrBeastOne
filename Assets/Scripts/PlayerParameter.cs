using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParameter : MonoBehaviour
{
    public  float health;
    public float water;
    public float eat;

    float waterAmount = 1f;
    float eatAmount = 0.5f;
    float healthAmount1 = 1f;
    float healtAmount2 = 0.5f;

    public Image HealthImage;
    public Image EatImage;
    public Image WaterImage;

    public Camera cam;
    public float range = 0.5f;

    public GameObject TextEat;
    public GameObject TextWater;
    public GameObject TextSleep;
    public GameObject MainCamera;
    public GameObject MainCamera2;
    public GameObject DieText;
    public GameObject DeadImage;
    public GameObject firstpersonaudio;
    public GameObject FonForButtons;
    public GameObject textSleep;
    public FirstPersonLook firstPersonLook;
    public FirstPersonMovement firstPersonMovement;

    bool isSleep;
    bool CheckButtonSleep;

    private void Start()
    {
        health = 100;
        water = 100;
        eat = 100;
        HealthImage.fillAmount = 1f;
        EatImage.fillAmount = 1f;
        WaterImage.fillAmount = 1f;
    }

    private void Update()
    {
        CheckAll();
        UpdateParametersEverySecond();
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddEat();
        }
    }

    public void UpdateParametersEverySecond()
    {
        if (water > 0)
        {
            water -= waterAmount * Time.deltaTime;
        }
        if (eat > 0)
        {
            eat -= eatAmount * Time.deltaTime;
        }

        WaterImage.fillAmount = water / 100;
        EatImage.fillAmount = eat / 100;
        HealthImage.fillAmount = health / 100;

        if (water <= 0 && eat <= 0)
        {
            health -= healthAmount1 * Time.deltaTime;
        }
        if (water <= 0)
        {
            health -= healtAmount2 * Time.deltaTime;
        }
        if (eat <= 0)
        { 
            health -= healtAmount2 * Time.deltaTime;
        }
        if (water >= 0 && eat >= 0 && health < 100) 
        {
            health += healtAmount2 * Time.deltaTime;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void AddEat()
    {
        RaycastHit hit;
        if( Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.GetComponent<Target>().CompareTag("Eat"))  
                {
                    if (eat <= 60)
                    {
                        eat += 40;
                        target.TakeDamage(50);
                    }
                    else
                    {
                        
                    }
                }
                else if (hit.transform.GetComponent<Target>().CompareTag("Water"))
                {
                    if (water <= 60)
                    {
                        water += 40;
                        target.TakeDamage(50);
                    }
                    else
                    {
                       
                    }
                }
            }
        }
    }

    public void CheckAll()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.GetComponent<Target>().CompareTag("Eat"))
                {
                    TextEat.SetActive(true);
                    TextWater.SetActive(false);
                }
                else if (hit.transform.GetComponent<Target>().CompareTag("Water"))
                {
                    TextWater.SetActive(true);
                    TextEat.SetActive(false);
                }
                else if(hit.transform.GetComponent<Target>().CompareTag("Bed"))
                {
                    TextSleep.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine(Sleep());
                    }
                    else if (CheckButtonSleep == true)
                    {
                        StartCoroutine(Sleep());
                    }
                }
                else
                {
                    TextSleep.SetActive(false);
                    TextWater.SetActive(false);
                    TextEat.SetActive(false);
                }
            }
            else if (target == null)
            {
                TextWater.SetActive(false);
                TextEat.SetActive(false);
                TextSleep.SetActive(false);
            }
        }
    } 

    IEnumerator Sleep()
    {
        int numberCount = 0;
        while (numberCount < 1)
        {
            textSleep.SetActive(true);
            isSleep = true;
            MainCamera2.SetActive(true);
            MainCamera.SetActive(false);
            yield return new WaitForSeconds(5f);
            Yandex.ShowAdvSleep();
            numberCount = 1;
            MainCamera.SetActive(true);
            MainCamera2.SetActive(false);
            isSleep = false;
            textSleep.SetActive(false);
        }
    }

    public void Die()
    {
        DeadImage.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        firstPersonMovement.speed = 0;
        firstpersonaudio.SetActive(false);
        firstPersonLook.sensitivity = 0;
        StartCoroutine(ShowAdvOpen());
    }
    IEnumerator ShowAdvOpen()
    {
        int number = 0;
        while (number < 1) 
        {
            yield return new WaitForSeconds(1.5f);
            Yandex.ShowAdvSleep();
            number++;
            StartCoroutine(FonForButtonsOpen());
        }
    }
    IEnumerator FonForButtonsOpen()
    {
        int number = 0;
        while (number < 1)
        {
            yield return new WaitForSeconds(1.5f);
            FonForButtons.SetActive(true);
            number++;
        }
    }
    public void SleepMobile()
    {
        CheckButtonSleep = true;
    }
}