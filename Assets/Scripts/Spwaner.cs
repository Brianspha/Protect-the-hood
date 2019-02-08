using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour {

    // Use this for initialization
    public GameObject[] AIS;
    public float maxSpawnTime = 5;
    public float curreSpawnTime;
    public int atATime = 1;
    public Transform[] from;
    public float delay = 4.5f;
    public float currentDelay;
    public bool activate = false;
    void Start () {
        currentDelay = delay;
        //curreSpawnTime = maxSpawnTime;
        //SpawnAI ();
        Debug.Log("Active: "+ activate);
    }

    // Update is called once per frame
    void Update()
    {
        if (activate && curreSpawnTime <= 0)
        {
            SpawnAI();
            curreSpawnTime = maxSpawnTime;
        }
        if (activate)
        {
            curreSpawnTime -= Time.deltaTime;
        }
    }

    private void SpawnAI () {
        Transform fromTemp = from[UnityEngine.Random.Range (0, from.Length)];
        Instantiate (AIS[UnityEngine.Random.Range (0, AIS.Length)], fromTemp.position, fromTemp.rotation);
    }
}