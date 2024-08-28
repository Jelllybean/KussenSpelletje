using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float jumpForce;
    public float rayLength = 1f;

    public int jumpCount = 2;
    public Vector2[] rayPositions;
    public bool isGrounded;
    public Transform pillowArt;

    public bool isColdDown;

    void Start()
    {
        isColdDown = true;
    }

    void Update()
    {
        isGrounded = CheckGround();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            StartCoroutine(DoJump());
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Rotate());
        }
    }

    IEnumerator DoJump()
    {
        //the initial jump
        rigidBody.AddForce(Vector2.up * jumpForce);

        yield return null;

        //can be any value, maybe this is a start ascending force, up to you
        float currentForce = jumpForce;
        int currentFrame = 0;

        while (Input.GetKey(KeyCode.Space) && currentForce > 0 && currentFrame < 50)
        {
            rigidBody.AddForce(Vector2.up * currentForce);
            currentFrame++;
            currentForce += 25 * Time.deltaTime;
            Debug.Log(currentFrame);

            yield return null;
        }
    }

    IEnumerator Rotate()
    {
        Debug.Log(pillowArt.eulerAngles.z);
        if(pillowArt.eulerAngles.z == 0)
        {
            while (pillowArt.eulerAngles.z < 180f)
            {
                pillowArt.Rotate(0, 0, Time.deltaTime * 360, Space.Self);
                yield return null;
            }
            //pillowArt.RotateAround(pillowArt.position, pillowArt.right, 180f);
            pillowArt.eulerAngles = new Vector3(0, 0, 180f);
        }
        else if(pillowArt.eulerAngles.z == 180f)
        {
            while (pillowArt.eulerAngles.z < 350f)
            {
                Debug.Log(pillowArt.eulerAngles.z);
                pillowArt.Rotate(0, 0, Time.deltaTime * 360, Space.Self);
                yield return null;
            }
            //pillowArt.RotateAround(pillowArt.position, pillowArt.right, 180f);
            pillowArt.eulerAngles = new Vector3(0, 0, 0);
        }
        isColdDown = !isColdDown;
        Debug.LogWarning(pillowArt.eulerAngles.z);
    }

    private bool CheckGround()
    {
        int isTrue = 0;
        int isFalse = 0;
        for (int i = 0; i < rayPositions.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + rayPositions[i].x, transform.position.y + rayPositions[i].y), -transform.up, rayLength);
            Debug.DrawRay(new Vector2(transform.position.x + rayPositions[i].x, transform.position.y + rayPositions[i].y), -transform.up * rayLength, Color.red, 0);
            if (hit)
            {
                isTrue++;
            }
            else
            {
                isFalse++;
            }
        }
        if (isTrue == rayPositions.Length)
        {
            return true;
        }
        else if (isFalse == rayPositions.Length)
        {
            return false;
        }
        else
        {
            return isGrounded;
        }
    }
}
