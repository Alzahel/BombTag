using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay_Player : MonoBehaviour
{
    public GameObject Player;
    public GameObject scoreManager;
    public GameObject scoreOverlay;
    public GameObject inventoryCoins;

    public Sprite[] imagesItems;
    public Sprite none;
    public Image imageItem;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
        InventoryUpdate();
    }

    private void ScoreUpdate()
    {
        if (GetComponent<Team>().TeamId == 1) scoreOverlay.GetComponent<Text>().text = scoreManager.GetComponent<ScoreManager>().coinsJ1.ToString();
        if (GetComponent<Team>().TeamId == 2) scoreOverlay.GetComponent<Text>().text = scoreManager.GetComponent<ScoreManager>().coinsJ2.ToString();
        if (GetComponent<Team>().TeamId == 3) scoreOverlay.GetComponent<Text>().text = scoreManager.GetComponent<ScoreManager>().coinsJ3.ToString();
        if (GetComponent<Team>().TeamId == 4) scoreOverlay.GetComponent<Text>().text = scoreManager.GetComponent<ScoreManager>().coinsJ4.ToString();
    }

    private void InventoryUpdate()
    {
        inventoryCoins.GetComponent<Text>().text = Player.GetComponent<Inventory>().coins.ToString();
        if (Player.GetComponent<Inventory>().haveBoostSpeed)
        {
            imageItem.sprite = imagesItems[0];
        }
        else if (Player.GetComponent<Inventory>().haveBearTrap)
        {
            imageItem.sprite = imagesItems[1];
        }
        else if (Player.GetComponent<Inventory>().haveShield)
        {
            imageItem.sprite = imagesItems[2];
        }
        else if (Player.GetComponent<Inventory>().haveMagnet)
        {
            imageItem.sprite = imagesItems[3];
        }
        else
        {
            imageItem.sprite = none;
        }
    }
}
