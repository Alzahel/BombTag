using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Match : MonoBehaviour
{
    public Sprite trois;
    public Sprite deux;
    public Sprite un;
    public Sprite zero;
    public Image img;
    public GameObject gameManager;
    public GameObject coinGenerator;
    public GameObject boxGenerator;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject player in gameManager.GetComponent<StartGame>().players)
        {
            player.GetComponent<Mouvementp1>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
        }
        img.sprite = trois;
        StartCoroutine(StartMatch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartMatch()
    {
        yield return new WaitForSeconds(1f);
        img.sprite = deux;
        yield return new WaitForSeconds(1f);
        img.sprite = un;
        yield return new WaitForSeconds(1f);
        img.sprite = zero;
        foreach (GameObject player in gameManager.GetComponent<StartGame>().players)
        {
            player.GetComponent<Mouvementp1>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
        }
        coinGenerator.SetActive(true);
        boxGenerator.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        img.enabled = false;
    }
}
