using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BombTime_init : MonoBehaviour
{
    private bool isBombTime;
    public GameObject gameManager;
    private GameObject[] players;
    private GameObject selectedPlayer;
    public GameObject[] bases;
    public GameObject coin_Generator;
    public float timeBombTime = 30f;
    private float memoryTimeBombTime;

    public GameObject bombTimeImage;


    void Start()
    {
        players = gameManager.GetComponent<StartGame>().players;
        bases = gameManager.GetComponent<StartGame>().bases;
        memoryTimeBombTime = timeBombTime;
    }

    private void Update()
    {
        if (isBombTime)
        {
            timerBombTime();
        }
    }

    public void startBombTime()
    {
        StartCoroutine(waitSoundBomb());
        isBombTime = true;

        selectedPlayer = players[Random.Range(0, players.Length)];
        selectedPlayer.GetComponent<PlayerBomb>().receiveBomb();
        

        foreach (GameObject child in bases)
        {
            child.GetComponent<EdgeCollider2D>().isTrigger = false;
        }
        coin_Generator.GetComponent<Cion_generator>().timeBetweenCoinGeneration = 0.5f;
        StartCoroutine(UIStartBombTime());
    }

    private IEnumerator waitSoundBomb()
    {
        yield return new WaitForSeconds(timeBombTime - 20f);
        SoundManager.PlaySound(SoundManager.Sound.Explosion);
    }

    private IEnumerator UIStartBombTime()
    {
        Image bombTime = bombTimeImage.GetComponent<Image>();
        while (bombTime.color.a < 0.99)
        {
            bombTime.color = Color.Lerp(bombTime.color, new Color(bombTime.color.r, bombTime.color.g, bombTime.color.b, 1), 4f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        while (bombTime.color.a > 0.01)
        {
            bombTime.color = Color.Lerp(bombTime.color, new Color(bombTime.color.r, bombTime.color.g, bombTime.color.b, 0), 2f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void endBombTime()
    {
        isBombTime = false;
        timeBombTime = memoryTimeBombTime;

        coin_Generator.GetComponent<Cion_generator>().timeBetweenCoinGeneration = 1.2f;

        foreach (GameObject child in bases)
        {
            child.GetComponent<EdgeCollider2D>().isTrigger = true;
        }

        foreach (GameObject player in players)
        {
            if (player.GetComponent<PlayerBomb>().haveBomb == true)
            {
                player.GetComponent<PlayerBomb>().exploseBomb();
                player.GetComponent<PlayerBomb>().leaveBomb();
                return;
            }
        }
    }

    private void timerBombTime()
    {
        timeBombTime -= Time.deltaTime;
        if (timeBombTime < 0f)
        {
            endBombTime();
        }
    }

}
