using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static StartGame gameStart;

    public GameObject game;
    public GameObject inputManager;
    public GameObject menu;

    public GameObject[] players;
    public GameObject[] bases;
    public GameObject[] overlayPlayers;
    

    public void Game()
    {
        int nbPlayer = 0;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length < 1) { return; }

        // gestion du tableau des joueurs
        
        foreach (GameObject player in players)
        {
            // gestion des bases des joeurs
            player.transform.position = bases[nbPlayer].transform.position;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            player.transform.gameObject.GetComponent<PlayerBomb>().baseOfPlayer = bases[nbPlayer];
            //gestion des overlays joeurs
            overlayPlayers[nbPlayer].GetComponent<Overlay_Player>().Player = player;

            nbPlayer++;
            player.name = "Player_" + nbPlayer.ToString();
        }


        game.SetActive(true);
        inputManager.SetActive(false);
        menu.SetActive(false);
    }

    private void Awake()
    {
        //gameStart = new StartGame();
    }
}
