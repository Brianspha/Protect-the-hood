using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnInfinePlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platforms;
    public float maxTimetoSpawn = 4;
    public float currentSpawnTime;
    public Transform currentPos;
    public float SizeApart = 24.9f;
    void Start()
    {
        currentPos.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y, currentPos.transform.position.z + SizeApart);
    }

    // Update is called once per frame
    void Update()
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
    public void SpawnPlatforms()
    {
        Debug.Log("CurrentPos: " + currentPos.position);
        Transform temp=(Instantiate(platforms[Random.Range(0, platforms.Length)], currentPos.position, currentPos.rotation) as GameObject).transform;
        currentPos.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y, currentPos.transform.position.z + SizeApart);
    }
}
