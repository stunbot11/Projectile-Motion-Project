using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public int page = 1;

    public void switchPage()
    {
        if (page == 1)
        {
            page = 2;
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if (page == 2)
        {
            page = 1;
            page1.SetActive(true);
            page2.SetActive(false);
        }
    }
}
