using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGO : MonoBehaviour
{
    ScoreManager scoreManager;
    public int scoreGO = 0;
    public Text puntosAlPerder;

    

    private void Update()
    {
        
        puntosAlPerder.text = scoreManager.score + "";
    }
}
