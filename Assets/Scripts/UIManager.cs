using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject setUI;
    public GameObject exitUI;
    public GameObject infoUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenSettingUI()
    {
        if (!setUI.activeSelf)
        {
            Time.timeScale = 0;
            setUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            setUI.SetActive(false);
        }
    }

    public void OpenExitUI()
    {
        if (!exitUI.activeSelf)
        {
            Time.timeScale = 0;
            exitUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            exitUI.SetActive(false);
        }
    }

    public void OpenInfoUI()
    {
        if (!infoUI.activeSelf)
        {
            Time.timeScale = 0;
            infoUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            infoUI.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
