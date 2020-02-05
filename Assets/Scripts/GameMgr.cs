using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance;
    
    public Transform topLine;
    
    
    private void Start()
    {
        instance = this;
    }
}
