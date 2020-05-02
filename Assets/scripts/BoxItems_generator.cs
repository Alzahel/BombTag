using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItems_generator : MonoBehaviour
{
    public List<GameObject> itemsBoxPlaces;

    private GameObject itemsBoxPlace;
    public float timeBetweenitemsBoxGeneration;


    void Start()
    {
        itemsBoxPlaces = new List<GameObject>();

        foreach (Transform child in transform)
        {
            itemsBoxPlaces.Add(child.gameObject);
        }

        StartCoroutine(GenerateCoin());
    }

    private void Update()
    {

    }

    IEnumerator GenerateCoin()
    {
        // spot is empty, we can spawn
        itemsBoxPlace = itemsBoxPlaces[Random.Range(0, itemsBoxPlaces.Count)];
        itemsBoxPlace.SetActive(true);
        yield return new WaitForSeconds(timeBetweenitemsBoxGeneration);
        StartCoroutine(GenerateCoin());
    }
}
