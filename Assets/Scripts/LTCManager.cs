using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LTCManager : MonoBehaviour
{

    public int gap = 2;
    public int menu_time = 2;

    private IEnumerator coroutine;

    private bool flag = false;
    private bool isPaused = false;

    System.Random random;

    public GameObject[] litecoins;

    public GameObject mainCanvas;
    public Text factsText;

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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Litecoin")
                {
                    Debug.Log(hit.collider.transform.parent.name);
                    pauseAnimation();
                    mainCanvas.SetActive(true);
                    factsText.text = hit.collider.transform.parent.name;
                    StopCoroutine(coroutine);

                    StartCoroutine("menuCoroutine");
                    
                }
            }
        }

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
            int rno = random.Next(1, litecoins.Length + 1);
            Debug.Log(rno);

            GameObject tempObj = litecoins[rno - 1];
            tempObj.GetComponentInChildren<showCoin>().makeActive();

            yield return new WaitForSeconds(gap);

            //if(isPaused)
            //    yield return new Wait
        }

    }

    void pauseAnimation()
    {
        foreach (GameObject obj in litecoins)
        {
            obj.GetComponentInChildren<Animator>().speed = 0;
        }
    }

    void resumeAnimation()
    {
        foreach (GameObject obj in litecoins)
        {
            obj.GetComponentInChildren<Animator>().speed = 1;
        }
    }

    public void closeMenu()
    {
        resumeAnimation();
        StartCoroutine(coroutine);
        mainCanvas.SetActive(false);
    }

    IEnumerator menuCoroutine()
    {
        yield return new WaitForSeconds(menu_time);

        //Debug.Log("Closing now");
        closeMenu();
    }
}
