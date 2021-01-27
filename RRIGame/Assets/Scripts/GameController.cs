using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button restartButton;
    public Button pauseButton;
    private bool paused;

    void Start()
    {
        restartButton.onClick.AddListener(restartLevel);
        pauseButton.onClick.AddListener(pauseGame);
        paused = false;
    }

    void restartLevel()
    {
        LapTimeManager.MilliCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void pauseGame()
    {
        if (paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        paused = !paused;
    }
}
