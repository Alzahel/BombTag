using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : MonoBehaviour
{
    public float timeBeaforeExplosion;

    private void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (!collision.GetComponent<Inventory>().isProtected)
            {
                collision.transform.gameObject.GetComponent<PlayerBomb>().die();
            }
        }
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(timeBeaforeExplosion);
        Destroy(gameObject);
    }
}
