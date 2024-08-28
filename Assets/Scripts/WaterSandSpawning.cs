using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSandSpawning : MonoBehaviour
{
    public static WaterSandSpawning instance;
    public GameObject sandPrefab;
    public GameObject waterPrefab;
    public Vector3 nextPosition;

    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 0.5f);   
    }

    public void Spawn()
    {
        int _random = Random.Range(0, 10);
        if(_random < 5)
        {
            Instantiate(sandPrefab, nextPosition, Quaternion.identity);
        }
        else if(_random >= 5)
        {
            Instantiate(waterPrefab, nextPosition, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
