using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerJoin : MonoBehaviour
{

    public GameObject game;
    public RuntimeAnimatorController[] anim;
    private int teamId = 1;

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<Team>().TeamId = teamId;
        playerInput.GetComponent<Animator>().runtimeAnimatorController = anim[teamId -1];
        teamId++;
    }
}
