using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cion_generator : MonoBehaviour
{

    public List<GameObject> coinPlaces;

    private GameObject coinPlace;
    public float timeBetweenCoinGeneration;


    void Start()
    {
        coinPlaces = new List<GameObject>();

        foreach (Transform child in transform)
        {
            coinPlaces.Add(child.gameObject);
        }

        StartCoroutine(GenerateCoin());
    }

    private void Update()
    {
        
    }

    IEnumerator GenerateCoin()
    {
        // spot is empty, we can spawn
        coinPlace = coinPlaces[Random.Range(0, coinPlaces.Count)];
        coinPlace.SetActive(true);
        yield return new WaitForSeconds(timeBetweenCoinGeneration);
        StartCoroutine(GenerateCoin());
    }

}
