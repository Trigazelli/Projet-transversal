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
    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(string LevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(LevelName);
    }
}
