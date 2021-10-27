using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour
{
    public bool estadoNube = false;

    public float timer1;
    public float timer2;

    public GameObject canvaGameoverQlo;
    
    

    public enum PlayerState
	{
        Idle,
        Asesino,
        Muerto,
        Nube
	}

    public PlayerState estadoJugador;

    public Image originalTransition;
    public Sprite[] idles;
    public Sprite[] asesinos;
    public Sprite[] muertes;
    public Sprite newCircle;
    public Sprite newSquare;
    public Sprite newTriangle;
    public Sprite newTransition;
    public Sprite newTransition2;
    public GameObject powerBG;
    public int randomNumber;
    public float tiempoFigurativo;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Transition");
        Time.timeScale = 1;
        originalTransition.sprite = newTransition;

        canvaGameoverQlo.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame


    //El rango (1, 3) significa que escoge entre 1 y 2 todo el rato.
    void Update()
    {
        States();

        //Que se cuente hasta 10.
        if (tiempoFigurativo < 10)
        {
            tiempoFigurativo = (tiempoFigurativo + 1 * Time.deltaTime);
        }

        //Cuando llega a 10 se pone la nube.
        if (tiempoFigurativo >= 10)
        {
            
            StartCoroutine("Transition");
            tiempoFigurativo = 0;

        }

        //  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

        if (estadoJugador == PlayerState.Nube)
        {
            timer1 = timer1 - 2f * Time.deltaTime;
                if (timer1 <= 0 && originalTransition.sprite == newTransition)
            {
                originalTransition.sprite = newTransition2;
                timer1 = timer2;
            }

            
            if (timer1 <= 0 && originalTransition.sprite == newTransition2)
            {
                originalTransition.sprite = newTransition;
                timer1 = timer2;
            }
        }

    }


    public void Shifting()
    {
        switch(randomNumber)
		{
            case 1:
                originalTransition.sprite = idles[randomNumber];
                break;

            case 2:
                originalTransition.sprite = idles[randomNumber];
                break;

            case 3:
                originalTransition.sprite = idles[randomNumber];
                break;
        }       

    }

    public void States()
	{
        
        switch (estadoJugador)
        {
            case PlayerState.Idle:

                originalTransition.sprite = idles[randomNumber];

                break;

            case PlayerState.Asesino:

                originalTransition.sprite = asesinos[randomNumber];

                break;

            case PlayerState.Muerto:

                switch (randomNumber)
                {
                    case 1:
                        originalTransition.sprite = muertes[randomNumber];
                        break;

                    case 2:
                        originalTransition.sprite = muertes[randomNumber];
                        break;

                    case 3:
                        originalTransition.sprite = muertes[randomNumber];
                        break;
                }

                break;

            case PlayerState.Nube:
               // originalTransition.sprite = newTransition;
                break;
        }



    }

    IEnumerator Transition()
    {
        originalTransition.sprite = newTransition;
        estadoJugador = PlayerState.Nube;
        randomNumber = Random.Range(1, 4);
        powerBG.SetActive(true);



        
        yield return new WaitForSeconds(2);
        Debug.Log("Fin de la transición");
        powerBG.SetActive(false);
        estadoJugador = PlayerState.Idle;
    }

    //Existe un codigo para hacer que el profe de mas plazo?

    public IEnumerator Muerte()
    {
        
        originalTransition.sprite = muertes[randomNumber];
        

        estadoJugador = PlayerState.Muerto;

        yield return new WaitForSeconds(.3f);
        canvaGameoverQlo.SetActive(true);
        Time.timeScale = 0;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);




    }

}
