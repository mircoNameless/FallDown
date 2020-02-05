using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material material;
    public Vector2 speed;
    
    
    public void Update()
    {
        material.mainTextureOffset += speed * Time.deltaTime;
    }
}
