using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }
    public int coinsJ1 = 0;
    public int coinsJ2 = 0;
    public int coinsJ3 = 0;
    public int coinsJ4 = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddCoins(int teamId, int nbCoins)
    {
        if (teamId == 1) coinsJ1 += nbCoins;
        if (teamId == 2) coinsJ2 += nbCoins;
        if (teamId == 3) coinsJ3 += nbCoins;
        if (teamId == 4) coinsJ4 += nbCoins;

    }
}
