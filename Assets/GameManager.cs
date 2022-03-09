using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GameMng;
    public GameObject ballPrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject scorePanel;
    public GameObject startMenu;
    public GameObject gameOverMenu;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Awake()
    {
        GameMng = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        SetBorders();
        startMenu.SetActive(true);
    }

    void Update()
    {
            if (Input.GetKey("escape")) {
            Application.Quit(); }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        GameObject Ball = Instantiate (ballPrefab);
        GameObject Player = Instantiate (playerPrefab);
        GameObject Enemy = Instantiate (enemyPrefab);
        scorePanel.SetActive(true);
    }

    private void SetBorders()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public void NewRound()
    {
        GameObject Ball = Instantiate (ballPrefab);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Paddle");
        foreach(GameObject go in gos)
            Destroy(go);
        gameOverMenu.SetActive(true);

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
