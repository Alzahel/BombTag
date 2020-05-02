using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Collider2D[] playerColliders;
    private Rigidbody2D rb;
    public Vector3 positionInitial;
    public LayerMask player;

    public float attractionForce = 10;
    public float maxDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        positionInitial = transform.position;
    }

    private void FixedUpdate()
    {
        playerColliders = Physics2D.OverlapCircleAll(transform.position, maxDistance, player);

        foreach (Collider2D player in playerColliders)
        {
            if (player.gameObject.GetComponent<Inventory>().isUsingMagnet)
            {
                Debug.Log(rb.velocity);
                Debug.Log((player.transform.position - transform.position) * attractionForce);
                rb.velocity = (player.transform.position - transform.position) * attractionForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.SetActive(false);
            positionInitial = transform.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, maxDistance);
    }
}
