using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowCursor : MonoBehaviour
{
    float raycase_depth = 100.0f;
    LayerMask floor_layer_mask;
    string floor_layer_name = "2D Floor";

    void Start()
    {
        floor_layer_mask = LayerMask.GetMask("2D Floor");
    }

    void Update () 
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        Vector3 mouse_position = Mouse.current.position.ReadValue();

        Ray mouse_ray = Camera.main.ScreenPointToRay(mouse_position);
        RaycastHit[] mouse_hits = Physics.RaycastAll(mouse_ray, raycase_depth, floor_layer_mask);

        if(mouse_hits.Length == 1)
        {
            Vector3 hit_position = mouse_hits[0].point;

            Vector3 local_hit_position = transform.InverseTransformPoint(hit_position);
            local_hit_position.y = 0;
            Vector3 look_position = transform.TransformPoint(local_hit_position);

            transform.LookAt(look_position, transform.up);
        }
    }
}
