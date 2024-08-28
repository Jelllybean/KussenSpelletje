using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSandGeneration : MonoBehaviour
{
    public List<GameObject> objectsToEnable = new List<GameObject>();
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        int _random = Random.Range(3, 8);
        Debug.Log(_random);
        for (int i = 0; i < _random; i++)
        {
            objectsToEnable[i].SetActive(true);
            objectsToEnable[i].transform.parent = null;
        }
        transform.localScale = new Vector3(transform.localScale.x + (_random -1), transform.localScale.y, transform.localScale.z);
        WaterSandSpawning.instance.nextPosition.x = WaterSandSpawning.instance.nextPosition.x + transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("DestroyObject", 5f);
        }
    }

    public void DestroyObject()
    {
        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            Destroy(objectsToEnable[i]);
        }
        Destroy(gameObject);
    }
}
