using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = objectToFollow.position + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x + offset.x, transform.position.y, -10);
    }
}
