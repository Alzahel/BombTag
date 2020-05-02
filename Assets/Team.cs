using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField]
    int teamId;

    public int TeamId { get => teamId; set => teamId = value; }
}
