using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTCManager : MonoBehaviour
{

    public int gap = 2;

    private IEnumerator coroutine;

    private bool flag = false;
    private bool isPaused = false;

    System.Random random;
    

    // Use this for initialization
    void Start()
    {
        random = new System.Random();

        coroutine = sampleCoroutine();
        flag = true;
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
            isPaused = !isPaused;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    flag = false;
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    flag = true;
        //}
    }

    IEnumerator sampleCoroutine()
    {
        while (flag)
        {
            int randomNumber = random.Next(1, 4);
            Debug.Log(randomNumber);

            
            yield return new WaitForSeconds(gap);

            while (isPaused)
            {
                Debug.Log("It is paused");
            }
        }
        
    }
}
