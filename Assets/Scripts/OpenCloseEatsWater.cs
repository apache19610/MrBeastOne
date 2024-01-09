using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseEatsWater : MonoBehaviour
{
    public GameObject[] eatsWater;
    public float timer;
    public float resultTimer;

    private void Start()
    {
        timer = 0; 
    }

    private void Update()
    {
        timer +=  1 * Time.deltaTime;
        resultTimer = ((int)(timer * 10)) / 10f;
        if (resultTimer == 5)  
        {
            GameObject newObj;
            newObj = eatsWater[Random.Range(0, 6)];
            newObj.SetActive(true);
        }
    }
}
