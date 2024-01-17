using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDays : MonoBehaviour
{
    public GameObject[] Days;
    public int numberSpawn = 6;

    private void Start()
    {
        StartCoroutine(OpenCloseWaterEat());
        numberSpawn = 6;
    }

    IEnumerator OpenCloseWaterEat()
    {
        while (numberSpawn >= 0)
        {
            GameObject newObj;
            newObj = Days[numberSpawn];
            newObj.SetActive(true);
            yield return new WaitForSeconds(600f);
            Destroy(Days[numberSpawn]);
            numberSpawn--;
        }
    }
}
