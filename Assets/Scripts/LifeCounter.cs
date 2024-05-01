using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] private int _life;
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
    }

    private void Update()
    {
        _livesDisplayer.SetText(_life.ToString());
    }
}
