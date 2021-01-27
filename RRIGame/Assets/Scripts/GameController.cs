using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(restartLevel);
    }

    void restartLevel()
    {
        LapTimeManager.MilliCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
