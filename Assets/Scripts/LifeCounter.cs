using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] public int _life;
    [SerializeField] private TextMeshProUGUI _livesDisplayer;
    public static LifeCounter Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _livesDisplayer.SetText(_life.ToString());
    }

    public void DecrementLife()
    {
        _life--;
        CheckIfGameLost();
    }

    private void Update()
    {
        _livesDisplayer.SetText(_life.ToString());
        Debug.Log(_life);
    }

    private void CheckIfGameLost()
    {
        if (_life <= 0)
        {
            SceneManager.LoadScene("Defeat");
        } else
        {
            LevelLoader.Instance.LoadNextLevel();
        }

    }
}
