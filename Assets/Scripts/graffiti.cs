using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graffiti : MonoBehaviour
{
    [SerializeField] private SwipeCalcul _calcul;
    [SerializeField] private float _maxTime;

    private SpriteRenderer _spriteRenderer;
    private float _x1;
    private float _x2;
    private float _startTime = 0f;
    private int _swipe = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        _x1 = Input.mousePosition.x;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        _x2 = Input.mousePosition.x;
        _getTime();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");
        _incrementTime();
    }

    private void _incrementTime()
    {
        _startTime += Time.deltaTime;
    }

    private void _getTime()
    {
        if (_startTime > _maxTime)
        {
            Debug.Log("not swiped");
        } else
        {
            if (_calcul.DetectLeftSwipe(_x1, _x2) || _calcul.DetectRightSwipe(_x1, _x2))
            {
                _swipe++;
                ChangeAlpha();
            }
        }
        _startTime = 0f;

        if (_swipe >= 5)
        {
            LevelLoader.Instance.LoadNextLevel();
        }
    }

    private void ChangeAlpha()
    {
        Color sprite = _spriteRenderer.color;
        sprite.a -= 0.2f;
        _spriteRenderer.color = sprite;
    }
}
