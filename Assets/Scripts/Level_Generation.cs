using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class Level_Generation : MonoBehaviour
{
    private float SpawnTime = 0.4f;
    float incr = 0;
    float height = 0;

    public List <GameObject> Platforms = new List<GameObject> ();

    public void Start()
    {
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        int rndplatform = Random.Range(0, Platforms.Count);
        Instantiate(Platforms[rndplatform], new Vector2(incr, height), Quaternion.identity);

        incr += Random.Range(6f, 10f);
        height = Random.Range(1.5f, -1.5f);

        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(Spawn());
    }
}
