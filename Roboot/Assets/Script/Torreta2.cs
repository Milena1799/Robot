using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta2 : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Robot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 destPos = transform.position - transform.TransformDirection(10, 0, 0);
        //Debug.DrawLine(transform.position,  destPos, Color.blue);
        Vector3 aimVector = player.position + new Vector3(0f, 1.9f, 0f);
        Vector3 dir = aimVector - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        //AUTOR: JORGE SÁNCHEZ
    }
}
