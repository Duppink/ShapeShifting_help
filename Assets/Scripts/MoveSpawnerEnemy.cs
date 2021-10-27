using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSpawnerEnemy : MonoBehaviour
{   public Transform canvas;
    public GameObject spawner;
    public GameObject enemy;
    public float timer = 3;
    public float velocity;
    public int stage;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       // transform.DOMoveX(125, 0.5f).SetEase(Ease.InOutSine).SetLoops(1000, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "caja")
        {
            velocity = velocity * -1;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - 1 * Time.deltaTime;

        transform.Translate(Vector3.right * velocity * Time.deltaTime);

        //SpawnEnemyPofavo();

    

       switch (ScoreManager.scoreManager.score)
        {
            case 10:
                stage = 1;
                break;

            case 20:
                stage = 2;
                break;

            case 30:
                stage = 3;
                break;

            case 40:
                stage = 4;
                break;

            case 50:
                stage = 5;
                break;

            case 60:
                stage = 6;
                break;

            case 70:
                stage = 7;
                break;

        } 


        switch (stage)
        {
            case 0:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.85f, 1f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 1:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.75f, .9f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 2:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.65f, .8f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 3:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.55f, .8f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 4:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.45f, .75f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 5:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(.35f, .7f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 6:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(0.25f, 0.65f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

            case 7:
                if (timer <= 0)
                {
                    timer = timer + Random.Range(0.15f, 0.55f);
                    //StartCoroutine("SpawnEnemy");
                    Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
                }
                break;

           
        }

        
    }

    /*public void SpawnEnemyPofavo()
    {
        if (timer <= 0)
        {
            timer = timer + Random.Range(0.25f, 0.75f);
            //StartCoroutine("SpawnEnemy");
            Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
        }
    } */
    //Soy un búho. Pero un búho triste, por que no he hecho lo de la presentacion aun y son las 5 AM.
    /* IEnumerator SpawnEnemy()
      {
          //while(true)
          {
              Instantiate(enemy, spawner.transform.position, spawner.transform.rotation, canvas);
              yield return new WaitForSeconds(Random.Range(3, 4));   
          }

      } */
}
