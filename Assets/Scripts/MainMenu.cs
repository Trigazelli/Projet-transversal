using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] bool Play;
    public void PlayGame()
    {
        LevelLoader.Instance.LoadNextLevel();
    }

    private void OnMouseDown()
    {
        if (Play)
        {
            PlayGame();
        } else
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !");
        Application.Quit();
    }
}
