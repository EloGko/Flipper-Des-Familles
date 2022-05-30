using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball, startButton, scoreText, quitButton, restartButton;

    int score;

    [SerializeField]
    Rigidbody2D left, right;

    [SerializeField]
    Vector3 startPos;

    public int multiplier;

    bool canPlay;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
        score = 0;
        multiplier = 1;
        canPlay = false;
    }

    private void Update()
    {
        if (!canPlay) return;
        if(Input.GetKeyUp(KeyCode.Q))
        {
            left.AddTorque(50f);
        }
        else
        {
            //left.AddTorque(-5f);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right.AddTorque(-50f);
        }
        else
        {
            //right.AddTorque(5f);
        }

    }

    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        quitButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void GameStart()
    {
        startButton.SetActive(false);
        scoreText.SetActive(true);
        Instantiate(ball, startPos, Quaternion.identity);
        canPlay = true;
    }

    public void GameQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
