using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject canvaPausa;

    public void MenuPause()
    {
        canvaPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void MenuResume()
    {
        canvaPausa.SetActive(false);
        Time.timeScale = 1;
    }

    
}
