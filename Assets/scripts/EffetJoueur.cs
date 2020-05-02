using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetJoueur : MonoBehaviour
{
    public Sprite shield;
    public Sprite bomb;
    public SpriteRenderer srEffect;

    private bool haveBomb;

    public Color currentColor;
    public Color colorStart;
    public Color colorFinal;

    private void Update()
    {
        if (haveBomb)
        {
            //cliotement de la bomb sur le joueur
            if (srEffect.material.color == colorStart)
            {
                currentColor = colorFinal;
            }
            else if (srEffect.material.color == colorFinal)
            {
                currentColor = colorStart;
            }
            srEffect.material.color = Color.Lerp(srEffect.material.color, currentColor, 50f * Time.deltaTime);
        }
    }

    public void showShield()
    {
        srEffect.sprite = shield;
    }

    public void showBomb()
    {
        srEffect.sprite = bomb;
        haveBomb = true;
    }

    public void hideEffet()
    {
        srEffect.sprite = null;
        haveBomb = false;
        srEffect.material.color = colorStart;
    }
}
