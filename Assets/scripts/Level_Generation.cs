using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class Level_Generation : MonoBehaviour
{
    private float SpawnTime = 1;
    float incr = 0;
    float height = 0;

    public GameObject platform;
    public GameObject platform2;
    public List <GameObject> Platforms = new List<GameObject> ();

    public void Start()
    {
        //Platforms.Add (platform);
        //Platforms.Add(platform2);
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        int rndplatform = Random.Range(0, Platforms.Count);
        Instantiate(Platforms[rndplatform], new Vector2(incr, height), Quaternion.identity);

        incr += Random.Range(2f, 5f);
        height = Random.Range(1.5f, -1.5f);

        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(Spawn());
    }
}
