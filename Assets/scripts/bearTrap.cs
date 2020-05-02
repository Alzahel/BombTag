using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearTrap : MonoBehaviour
{
    public float timeStunBearTrap;
    public float timeBearTrap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.GetComponent<Team>().TeamId != GetComponent<Team>().TeamId)
            {
                if (collision.GetComponent<Inventory>().isProtected)
                {
                    collision.GetComponent<Inventory>().isProtected = false;
                    collision.GetComponent<EffetJoueur>().hideEffet();
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine(stunBearTrap(collision.gameObject));
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator stunBearTrap(GameObject player)
    {
        player.GetComponent<Mouvementp1>().isStun = true;
        yield return new WaitForSeconds(timeStunBearTrap);
        player.GetComponent<Mouvementp1>().isStun = false;
        Destroy(gameObject);
    }
}
