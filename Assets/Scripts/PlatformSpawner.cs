using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject[] platforms;
    public float maxTimetoSpawn = 4;
    public float currentSpawnTime;
    Transform currentPos;
    public float SizeApart = 24.9f;
    public bool Active = false;
    void Start()
    {
        currentPos = transform;
       // currentPos.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y, currentPos.transform.position.z + SizeApart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            if (currentSpawnTime <= 0)
            {
                currentSpawnTime = maxTimetoSpawn;
                SpawnPlatforms();
            }
            else
            {
                currentSpawnTime -= Time.deltaTime;
            }
        }
    }
    public void SpawnPlatforms()
    {
        Debug.Log("CurrentPos: " + currentPos.position);
        Transform temp = (Instantiate(platforms[Random.Range(0, platforms.Length)], currentPos.position, currentPos.rotation) as GameObject).transform;
        float colliderZ = temp.gameObject.GetComponent<BoxCollider>().size.z;
        currentPos.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y, currentPos.transform.position.z + colliderZ*temp.transform.localScale.z);
    }
}