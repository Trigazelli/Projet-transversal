using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float BaseScale;
    [SerializeField] private float speed = 1f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        float scale = Mathf.PingPong(Time.time * speed, 1);
        _transform.localScale = new Vector3 (BaseScale + scale, BaseScale + scale, BaseScale);
    }
}
