using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Canvas canvas;
    [SerializeField] private string phrase;

    private SpriteRenderer _sprite;

    private bool _lowerLife = true;
    private float _time;

    private void Start()
    {
        StartCoroutine(Indication());
        _time = duration;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _decrementTime();
        _checkIfLifeLost();
        _displaytime();
    }

    private void _decrementTime()
    {
        _time -= Time.deltaTime;
    }

    private void _displaytime()
    {
        _sprite.sprite = sprites[Mathf.Max(0, Mathf.FloorToInt(_time))];
    }

    private void _checkIfLifeLost()
    {
        if (_time < 0f)
        {
            if (_lowerLife)
            {
                LifeCounter.Instance.DecrementLife();
                _lowerLife = false;

            }
        }
    }

    private IEnumerator Indication()
    {
        textMeshPro.SetText(phrase);
        yield return new WaitForSeconds(1);
        canvas.enabled = false;
    }
}
