using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyFigure : MonoBehaviour
{
    public enum Estado
	{
        Idle,
        Dead
	}

    public Estado estadoEnemigo = Estado.Idle;

    public ChangeImage figuraPlayer;
    
    public Image enemyFigure;
    public Sprite[] badShapes;
    public Sprite[] badShapesDead;
    public int randomNumberEnemy;

    public float deathTime = 0.5f;
    public float timeDead;

    // Start is called before the first frame update
    void Start()
    {
        figuraPlayer = GameObject.FindGameObjectWithTag("shift").GetComponent<ChangeImage>();
        randomNumberEnemy = Random.Range(1, 4);
        enemyFigure.sprite = badShapes[randomNumberEnemy];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeDead > 0.4f)
		{
            if(figuraPlayer.estadoJugador != ChangeImage.PlayerState.Nube)
			{
                figuraPlayer.estadoJugador = ChangeImage.PlayerState.Idle;
            }
            
            Destroy(gameObject);
		}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (figuraPlayer.randomNumber == randomNumberEnemy)
            {
                ScoreManager.scoreManager.RaiseScore(1);
                enemyFigure.sprite = badShapesDead[randomNumberEnemy];
                StartCoroutine("EnemyDeath");

            }

            if (figuraPlayer.originalTransition.sprite == figuraPlayer.newTransition || figuraPlayer.originalTransition.sprite == figuraPlayer.newTransition2)
            {
                ScoreManager.scoreManager.RaiseScore(1);
                enemyFigure.sprite = badShapesDead[randomNumberEnemy];
                StartCoroutine("EnemyDeath");
            }


            //muerteplayer
            if (figuraPlayer.randomNumber != randomNumberEnemy && figuraPlayer.originalTransition.sprite != figuraPlayer.newTransition && figuraPlayer.estadoJugador != ChangeImage.PlayerState.Nube)
            {
                StartCoroutine(figuraPlayer.Muerte());

            }



        }

        if(collision.tag == "KillBox")
		{
            Destroy(gameObject);
        }
       

    }

    //Juro que algun dia me voy a matar igual que este cuadrado maldito

    IEnumerator EnemyDeath()
    {
        float startTime = Time.time;

        while (Time.time < startTime + deathTime)
        {
            estadoEnemigo = Estado.Dead;

            if(figuraPlayer.estadoJugador != ChangeImage.PlayerState.Nube)
			{
                figuraPlayer.estadoJugador = ChangeImage.PlayerState.Asesino;
            }

            

            timeDead = timeDead + 1 * Time.deltaTime;

            yield return null;
        }
    }


}
