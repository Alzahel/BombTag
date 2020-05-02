using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject EndMenu;
    public GameObject[] players;
    public GameObject game;
    public GameObject ScoreManager;

    public GameObject Pscore1;
    public GameObject Pscore2;
    public GameObject Pscore3;
    public GameObject Pscore4;

    private int score1;
    private int score2;
    private int score3;
    private int score4;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameEnding()
    {

        score1 = ScoreManager.GetComponent<ScoreManager>().coinsJ1;
        score2 = ScoreManager.GetComponent<ScoreManager>().coinsJ2;
        score3 = ScoreManager.GetComponent<ScoreManager>().coinsJ3;
        score4 = ScoreManager.GetComponent<ScoreManager>().coinsJ4;


        players = GetComponent<StartGame>().players;
        foreach (GameObject child in players)
        {
            child.SetActive(false);
        }

        Pscore1.GetComponent<Text>().text = score1.ToString();
        Pscore2.GetComponent<Text>().text = score2.ToString();
        Pscore3.GetComponent<Text>().text = score3.ToString();
        Pscore4.GetComponent<Text>().text = score4.ToString();

        game.SetActive(false);
        EndMenu.SetActive(true);

    }
}
