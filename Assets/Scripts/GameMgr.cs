using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance;

    public Transform topLine;
    public PlayerController player;
    public Transform deadLine;

    public List<GameObject> platforms;

    private bool lastSpike = false;


    private void Awake()
    {
        instance = this;
        StartCoroutine(StartCreate());
    }

    private float spawnTime = 1.5f;
    private IEnumerator StartCreate()
    {
        CreatePlatform();
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(StartCreate());
    }

    public void CreatePlatform()
    {
        Vector3 position = deadLine.position;
        position.x = Random.Range(-2f, 2f);
        int index = Random.Range(0, platforms.Count);

        if (index == 3)
        {
            lastSpike = true;
        }

        if (lastSpike)
        {
            while (index == 4)
            {
                index = Random.Range(0, platforms.Count);
            }
        }

        Instantiate(platforms[index], position, Quaternion.identity, deadLine);

    }
}
