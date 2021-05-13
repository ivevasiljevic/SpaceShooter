using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] hazards;
    int hazardCount = 10;
    float startWait = 1.0f;
    float spawnWait = 0.5f;
    float waveWait = 4.0f;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    int score;
    bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScoreText();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(!gameOver)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-6.0f, 6.0f), 5.0f, 16.0f);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' to restart";
    }
}
