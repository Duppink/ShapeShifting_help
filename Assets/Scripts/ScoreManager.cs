using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static ScoreManager scoreManager;
    public int score;
    public Text scoreText;
    public Text scoreGameOver;

    private void Start()
    {
       scoreManager = this;
      // DontDestroyOnLoad(gameObject);
    }

   
    public void RaiseScore(int s)
    {
        score += s;
        scoreText.text = score + "";

 
        scoreGameOver.text = score + "";
    }

    
}
