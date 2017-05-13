using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Canvas shopCanvas;

    // Use this for initialization
    void Start()
    {
        GameObject shopObj = GameObject.FindWithTag("ShopCanvas");
        shopCanvas = shopObj.GetComponent<Canvas>();
        EnableShopCanvas();
    }

    void EnableShopCanvas()
    {
        if (shopCanvas != null)
        {
            shopCanvas.enabled = (Time.timeScale == 0);
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        EnableShopCanvas();
    }
}
