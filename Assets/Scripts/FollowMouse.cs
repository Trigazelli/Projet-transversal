using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

/*    private void Start()
    {
        Cursor.visible = false;
    }*/

    private void Update()
    {
        // Debug.Log(transform.position);
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(MousePos.x + offsetX, MousePos.y + offsetY, 1);
    }
}
