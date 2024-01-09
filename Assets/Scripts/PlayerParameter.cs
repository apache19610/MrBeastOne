using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public  float health;
    public float water;
    float waterAmount = 1f;
    public float eat;
    float eatAmount = 0.5f;
    
    public Camera cam;
    public float range = 5;

    private void Start()
    {
        health = 100;
        water = 100;
        eat = 100;
    }

    private void Update()
    {
        UpdateParametersEverySecond();
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddEat();
        }
    }

    public void UpdateParametersEverySecond()
    {
        water -= waterAmount * Time.deltaTime;
        eat -= eatAmount * Time.deltaTime;

        if (water <= 0 && eat <= 0)
        {
            health -= waterAmount * Time.deltaTime;
        }
        else if (water <= 0)
        {
            health -= eatAmount * Time.deltaTime;
        }
        else if (eat <= 0)
        {
            health -= eatAmount * Time.deltaTime;
        }
        else if (water >= 0 && eat >= 0 && health < 100) 
        {
            health += eatAmount * Time.deltaTime;
        }
        if (health <= 0)
        {
            Debug.Log("We are die");
        }
    }

    public void AddEat()
    {
        RaycastHit hit;
        if( Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.GetComponent<Target>().CompareTag("Eat"))  
                {
                    if (eat <= 80)
                    {
                        eat += 20;
                        target.TakeDamage(50);
                    }
                    else
                    {
                        
                    }
                }
                else if (hit.transform.GetComponent<Target>().CompareTag("Water"))
                {
                    if (water <= 80)
                    {
                        water += 20;
                        target.TakeDamage(50);
                    }
                    else
                    {
                       
                    }
                }
            }
        }
    }
}
