using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphics : MonoBehaviour
{
    public GameObject PP;
    private bool boolPP = true;

    public void ChangeGraphics()
    {
        boolPP = !boolPP;
        PP.SetActive(boolPP);
    }
}
