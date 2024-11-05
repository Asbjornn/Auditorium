using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMouse : MonoBehaviour
{
    public MouseManager mouseManager;
    public Vector2 vector;

    // Update is called once per frame
    void Update()
    {
        transform.position = mouseManager.mousePositionWorld - vector;
    }
}
