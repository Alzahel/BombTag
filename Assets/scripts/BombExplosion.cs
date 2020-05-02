using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject explosionPrefab;
    public float maxDistance;
    public float timeBetweenExplosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startExplosion());
    }


    private void CreateExplosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //left explosion :

        StartCoroutine(explosionLeft());

        //right explosion

        StartCoroutine(explosionRight());

        //up explosion

        StartCoroutine(explosionUp());

        //down explosion

        StartCoroutine(explosionDown());

        //top left

        StartCoroutine(explosionTopLeft());

        //top right

        StartCoroutine(explosionTopRight());

        //down left

        StartCoroutine(explosionDownLeft());

        //down right

        StartCoroutine(explosionDownRight());
    }

    IEnumerator startExplosion()
    {
        yield return new WaitForSeconds(0f);
        CreateExplosion();
    }

    IEnumerator explosionLeft()
    {

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.left);
        float distanceExplosion = takeDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x - actualDistance, transform.position.y), Quaternion.identity);
            actualDistance++;
        }
        
    }

    IEnumerator explosionRight()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right);
        float distanceExplosion = takeDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x + actualDistance, transform.position.y), Quaternion.identity);
            actualDistance++;
        }
    }
    
    IEnumerator explosionUp()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up);
        float distanceExplosion = takeDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y + actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }

    IEnumerator explosionDown()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
        float distanceExplosion = takeDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x, transform.position.y - actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }


    //diagonal explosions


    IEnumerator explosionTopLeft()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(-1, 1));
        float distanceExplosion = takeDiagonalDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x - actualDistance, transform.position.y + actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }

    IEnumerator explosionTopRight()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(1, 1));
        float distanceExplosion = takeDiagonalDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x + actualDistance, transform.position.y + actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }

    IEnumerator explosionDownLeft()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(-1, -1));
        float distanceExplosion = takeDiagonalDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x - actualDistance, transform.position.y - actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }

    IEnumerator explosionDownRight()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(1, -1));
        float distanceExplosion = takeDiagonalDistance(hits);
        float actualDistance = 1f;
        while (actualDistance < distanceExplosion && actualDistance < maxDistance)
        {
            yield return new WaitForSeconds(timeBetweenExplosion);
            Instantiate(explosionPrefab, new Vector2(transform.position.x + actualDistance, transform.position.y - actualDistance), Quaternion.identity);
            actualDistance++;
        }
    }

    private float takeDistance(RaycastHit2D[] hits)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.tag == "Wall")
            {
                return hit.distance;
            }
        }

        return 0f;
    }

    private float takeDiagonalDistance(RaycastHit2D[] hits)
    {
        float distanceExplosion = takeDistance(hits);
        distanceExplosion = Mathf.Sqrt(distanceExplosion * distanceExplosion / 2);
        return distanceExplosion;
    }
}
