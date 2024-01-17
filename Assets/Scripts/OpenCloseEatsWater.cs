using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseEatsWater : MonoBehaviour
{
    public GameObject[] eatsWater;
    public int numberSpawn = 20;

    private void Start()
    {
        StartCoroutine(OpenCloseWaterEat());
        numberSpawn = 20;
    }

    private void Update()
    {

    }

    IEnumerator OpenCloseWaterEat()
    {
        while (numberSpawn >= 0) 
        {
            GameObject newObj;
            newObj = eatsWater[numberSpawn];
            newObj.SetActive(true);
            yield return new WaitForSeconds(180f);
            Destroy(eatsWater[numberSpawn]);
            numberSpawn--;
        }
    }
}