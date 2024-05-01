using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] public static int _life = 5;
    private SpriteRenderer _livesDisplayer;
    [SerializeField] private Sprite[] sprites;

    public static LifeCounter Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        _livesDisplayer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
        _livesDisplayer.sprite = sprites[_life];
    }

    public void DecrementLife()
    {
        _life--;
        CheckIfGameLost();
    }

    private void Update()
    {
        _livesDisplayer.sprite = sprites[_life];
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
