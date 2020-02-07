using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance;

    public Transform topLine;
    public PlayerController player;
    public Transform deadLine;

    public List<GameObject> platforms;

    public Text score;
    public GameObject gameOver;

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

    private float distacne = 0.7f;
    public void CreatePlatform()
    {
        int times = Random.Range(1, 3);
        float posX = 0;
        for (int i = 0; i < times; i++)
        {
            Vector3 position = deadLine.position;
            if (Mathf.Approximately(posX, 0))
            {
                position.x = Random.Range(-2f, 2f);
                posX = position.x;
            }
            else
            {
                while (position.x < posX + distacne && position.x > posX - distacne)
                {
                    position.x = Random.Range(-2f, 2f);
                }
                posX = position.x;
            }
            int index = Random.Range(0, platforms.Count);

            if (index == 3)
            {
                lastSpike = true;
            }

            if (lastSpike)
            {
                while (index == 3)
                {
                    index = Random.Range(0, platforms.Count);
                }
            }

            Instantiate(platforms[index], position, Quaternion.identity, deadLine);
        }
    }

    public void RestartGame()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }

    private void Update()
    {
        score.text = Time.timeSinceLevelLoad.ToString("00");
    }
}
