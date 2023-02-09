using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    void Update () 
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
 
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
    }
}
