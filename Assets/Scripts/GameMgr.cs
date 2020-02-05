using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance;

    public Transform topLine;
    public PlayerController player;
    
    
    private void Start()
    {
        instance = this;
    }
}
