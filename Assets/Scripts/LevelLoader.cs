using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime = 1f;
    private static LevelLoader _instance;

    public static LevelLoader Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
