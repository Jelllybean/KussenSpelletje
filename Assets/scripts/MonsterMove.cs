using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    int speed = 600;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(speed * Time.deltaTime, transform.position.y);
    }
}
