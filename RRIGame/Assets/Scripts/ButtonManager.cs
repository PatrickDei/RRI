using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string NewGameLevel)
    {
        SceneManager.LoadScene("RaceScene");
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
