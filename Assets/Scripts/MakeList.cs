using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeList : MonoBehaviour
{

    [SerializeField] int currentIndex;
    public GameObject next;
    public GameObject prev;
    public GameObject[] pages;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectPage(int i)
    {
        currentIndex += i;
        foreach (GameObject x in pages)
        {
            x.SetActive(false);
        }

        pages[currentIndex].SetActive(true);

        if (currentIndex >= pages.Length-1)
        {
            next.SetActive(false);
        }
        else if (currentIndex <= 0)
        {
            prev.SetActive(false);
        }
        else
        {
            next.SetActive(true);
            prev.SetActive(true);
        }

    }
}
