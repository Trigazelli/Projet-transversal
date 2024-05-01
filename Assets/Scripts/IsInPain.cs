using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInPain : MonoBehaviour
{
    private Animator _anim;
    private SwipeDetection _swipeDetection;
    private int lastValue;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _swipeDetection = GetComponent<SwipeDetection>();
        lastValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_swipeDetection.Swipe != lastValue)
        {
            lastValue = _swipeDetection.Swipe;
            StartCoroutine(ChangeAnim());
        }
    }

    private IEnumerator ChangeAnim()
    {
        _anim.SetBool("Pain", true);
        yield return new WaitForSeconds(0.1f);
        _anim.SetBool("Pain", false);
    }
}
