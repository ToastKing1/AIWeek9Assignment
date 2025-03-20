using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerScript : MonoBehaviour
{

    public GameObject servedFood;
    public float timer;
    public float timeLimit = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (servedFood.activeInHierarchy)
        {
            timer += 1 * Time.deltaTime;
        }

        if (timer > timeLimit)
        {
            servedFood.SetActive(false);
            timer = 0;
            
        }

    }
}
