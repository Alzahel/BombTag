using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public bool haveBomb = false;

    public float boostSpeed;
    public float timeStunWhenTakeBomb;

    public LayerMask player;
    public Collider2D[] hitColliders;
    public RaycastHit2D[] hits;
    public GameObject baseOfPlayer;
    public GameObject bombExplosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && haveBomb)
        {
            if (collision.gameObject.GetComponent<Inventory>().isProtected) { return; }
            leaveBomb();
            StartCoroutine(GetComponent<Inventory>().spawnShield());
            collision.gameObject.GetComponent<PlayerBomb>().receiveBomb();
        }
    }

    public void receiveBomb()
    {
        haveBomb = true;
        StartCoroutine(stunWhenTakeBomb());
        GetComponent<Mouvementp1>().speed += boostSpeed;
        GetComponent<EffetJoueur>().showBomb();
    }

    public void leaveBomb()
    {
        haveBomb = false;
        StartCoroutine(WaitEndBoostSpeed());
        GetComponent<EffetJoueur>().hideEffet();
    }

    IEnumerator stunWhenTakeBomb()
    {
        GetComponent<Mouvementp1>().isStun = true;
        yield return new WaitForSeconds(timeStunWhenTakeBomb);
        GetComponent<Mouvementp1>().isStun = false;
    }

    public void exploseBomb()
    {
        float xPosition = Mathf.FloorToInt(transform.position.x) + 0.5f;

        float yPosition = Mathf.FloorToInt(transform.position.y) + 0.5f;

        Vector2 positionExplosion = new Vector2(xPosition, yPosition);

        Instantiate(bombExplosionPrefab, positionExplosion , Quaternion.identity);
    }

    public void die()
    {
        GetComponent<Inventory>().coins = 0;
        transform.position = baseOfPlayer.transform.position;
    }

    private IEnumerator WaitEndBoostSpeed()
    {
        yield return new WaitForSeconds(GetComponent<Inventory>().timeProtection);
        GetComponent<Mouvementp1>().speed -= boostSpeed;
    }
}
