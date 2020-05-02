using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins;
    public int maxCoins;
    public GameObject Overlay;

    public int Coins { get => coins; set => coins = value; }

    public bool haveBoostSpeed;
    public float boostSpeed;
    public float timeBoostSpeed;

    public bool haveBearTrap;
    public GameObject bearTrapPrefab;

    public bool haveShield;
    public bool isProtected;
    public float timeProtection;

    public bool haveMagnet;
    public bool isUsingMagnet;
    public float durationMagnet = 10f;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "base")
        {
            if (collision.gameObject.GetComponent<Team>().TeamId == GetComponent<Team>().TeamId)
            {
                ScoreManager.instance.AddCoins(GetComponent<Team>().TeamId, coins);
                coins = 0;
            }
        }

        if (collision.gameObject.tag == "boxItems")
        {
            if (!haveBearTrap && !haveBoostSpeed && !haveShield) randomItems();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin" && coins < maxCoins)
        {
            coins += 1;
        }
    }



    private void randomItems()
    {
        int rngItems = Random.Range(1, 5);
        
        if(rngItems == 1)
        {
            haveBoostSpeed = true;
        }else if (rngItems == 2)
        {
            haveBearTrap = true;
        }else if (rngItems == 3)
        {
            haveShield = true;
        }
        else if (rngItems == 4)
        {
            haveMagnet = true;
        }
    }

    public void OnItems()
    {
        if (GetComponent<PlayerBomb>().haveBomb) return;
        if (haveBoostSpeed) 
        { 
            StartCoroutine(performBoostSpeed());
            haveBoostSpeed = false;
        }else if (haveBearTrap)
        {
            spawnBearTrap();
            
        }else if (haveShield)
        {
            StartCoroutine(spawnShield());
        }else if (haveMagnet)
        {
            StartCoroutine(performMagnet());
        }
    }

    IEnumerator performBoostSpeed()
    {
        gameObject.GetComponent<Mouvementp1>().speed += boostSpeed;
        yield return new WaitForSeconds(timeBoostSpeed);
        gameObject.GetComponent<Mouvementp1>().speed -= boostSpeed;
    }

    private void spawnBearTrap()
    {
        float xPosition = Mathf.FloorToInt(transform.position.x) + 0.5f;
        float yPosition = Mathf.FloorToInt(transform.position.y) + 0.5f;
        Vector2 spawnPos = new Vector2(xPosition, yPosition);

        GameObject bearTrap = (GameObject)Instantiate(bearTrapPrefab, spawnPos, Quaternion.identity);
        bearTrap.GetComponent<Team>().TeamId = GetComponent<Team>().TeamId;
        haveBearTrap = false;
    }

    public IEnumerator spawnShield()
    {
        haveShield = false;
        GetComponent<EffetJoueur>().showShield();
        isProtected = true;
        yield return new WaitForSeconds(timeProtection);
        isProtected = false;
        GetComponent<EffetJoueur>().hideEffet();
    }

    private IEnumerator performMagnet()
    {
        haveMagnet = false;
        isUsingMagnet = true;
        yield return new WaitForSeconds(durationMagnet);
        isUsingMagnet = false;
    }
}
